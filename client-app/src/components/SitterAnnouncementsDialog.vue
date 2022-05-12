<template>
  <v-dialog
    v-model="active"
    persistent
    max-width="600px"
    min-width="360px"
    scrollable
    @click:outside="cancel"
    @keydown.esc="cancel"
  >
    <div>
      <v-tabs
        v-model="tab"
        show-arrows
        background-color="deep-purple accent-4"
        icons-and-text
        dark
        grow
      >
        <v-tabs-slider color="purple darken-4"></v-tabs-slider>
        <v-tab v-for="i in tabs" :key="i.name">
          <v-icon large>{{ i.icon }}</v-icon>
          <div class="caption py-1">{{ i.name }}</div>
        </v-tab>
        <v-tab-item>
          <v-card class="px-4">
            <v-card-text>
              <v-form ref="addForm" v-model="valid" @submit.prevent="submit">
                <v-row>
                  <v-col cols="6" sm="6" md="6">
                    <DateTimePicker
                      label="From"
                      v-model="newAnnouncement.startDate"
                      :disabled="true"
                    >
                      <template v-slot:dateIcon
                        ><v-icon>mdi-calendar</v-icon></template
                      >
                      <template v-slot:timeIcon
                        ><v-icon>mdi-clock</v-icon></template
                      >
                    </DateTimePicker>
                  </v-col>
                  <v-col cols="6" sm="6" md="6">
                    <DateTimePicker
                      label="To"
                      v-model="newAnnouncement.endDate"
                      :disabled="true"
                    >
                      <template v-slot:dateIcon
                        ><v-icon>mdi-calendar</v-icon></template
                      >
                      <template v-slot:timeIcon
                        ><v-icon>mdi-clock</v-icon></template
                      >
                    </DateTimePicker>
                  </v-col>
                  <v-col cols="8">
                    <v-text-field
                      v-model="newAnnouncement.title"
                      :rules="[rules.required]"
                      label="Title"
                      readonly
                    ></v-text-field>
                  </v-col>
                  <v-col cols="4">
                    <v-select
                      v-model="newAnnouncement.petId"
                      :items="pets"
                      :loading="selectLoading"
                      :rules="rules.text"
                      label="Pet"
                      readonly
                    ></v-select>
                  </v-col>
                  <v-col cols="12">
                    <v-textarea
                      v-model="newAnnouncement.description"
                      color="teal"
                      readonly
                    >
                      <template v-slot:label>
                        <div>Description <small>(optional)</small></div>
                      </template>
                    </v-textarea>
                  </v-col>
                  <v-col class="d-flex ml-auto" cols="12" sm="3" xsm="12">
                    <v-btn x-large block @click="cancel">Close</v-btn>
                  </v-col>
                  <v-col class="d-flex" cols="12" sm="3" xsm="12">
                    <v-btn
                      x-large
                      block
                      :disabled="!valid || hasSitter"
                      :color="color"
                      type="submit"
                    >
                      {{
                        hasSitter
                          ? isAccepted
                            ? "Accepted"
                            : "Rejected"
                          : "Apply"
                      }}
                    </v-btn>
                  </v-col>
                </v-row>
              </v-form>
            </v-card-text>
          </v-card>
        </v-tab-item>
      </v-tabs>
    </div>
  </v-dialog>
</template>

<script>
import axios from "axios";
import cfg from "@/config/config.js";
// import moment from "moment";
import DateTimePicker from "./DateTimePicker.vue";

export default {
  components: {
    DateTimePicker,
  },
  props: ["user", "announcement"],
  data() {
    return {
      active: true,
      tab: 0,
      tabs: [{ name: "Announcement", icon: "mdi-message-alert" }],
      valid: false,
      rules: {
        required: (value) => !!value || "Required.",
        min: (v) => (v && v.length >= 4) || "Min 4 characters",
        text: [(val) => (val || "").length > 0 || "This field is required"],
      },
      pets: [],
      selectLoading: true,
      newAnnouncement: { ...this.announcement },
      offer: null,
    };
  },
  async mounted() {
    let result = await axios.get(
      `${cfg.BACKEND_ADDR}/pets/${this.announcement.petId}`
    );
    const pet = result.data;
    this.pets.push({
      text: `${pet.name}, ${pet.sex} (${pet.age}yrs)`,
      value: pet.id,
      disabled: false,
    });
    this.selectLoading = false;
    if (!this.announcement.offerId) return;
    result = await axios.get(
      `${cfg.BACKEND_ADDR}/offers/${this.announcement.offerId}`
    );
    this.offer = result.data;
  },
  computed: {
    hasSitter() {
      return this.announcement.offerId != null;
    },
    isAccepted() {
      return this.user.id == this.offer?.sitterId;
    },
    color() {
      if (!this.hasSitter) return "success";
      if (this.isAccepted) return "success";
      return "error";
    },
  },
  methods: {
    cancel() {
      this.$emit("close");
    },
    submit() {
      if (this.$refs.addForm.validate()) {
        this.$emit("submit-apply", this.newAnnouncement);
      }
    },
  },
};
</script>
