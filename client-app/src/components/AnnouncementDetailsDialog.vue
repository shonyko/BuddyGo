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
                      required
                    ></v-text-field>
                  </v-col>
                  <v-col cols="4">
                    <v-select
                      v-model="newAnnouncement.petId"
                      :items="pets"
                      :loading="selectLoading"
                      :rules="rules.text"
                      label="Pets"
                      required
                    ></v-select>
                  </v-col>
                  <v-col cols="12">
                    <v-textarea
                      v-model="newAnnouncement.description"
                      color="teal"
                      clearable
                    >
                      <template v-slot:label>
                        <div>Description <small>(optional)</small></div>
                      </template>
                    </v-textarea>
                  </v-col>
                  <v-col class="d-flex" cols="12" sm="3" xsm="12">
                    <v-btn
                      x-large
                      block
                      :disabled="!valid"
                      color="error"
                      @click="remove"
                    >
                      Delete
                    </v-btn>
                  </v-col>
                  <v-col class="d-flex ml-auto" cols="12" sm="3" xsm="12">
                    <v-btn x-large block @click="cancel">Close</v-btn>
                  </v-col>
                  <v-col class="d-flex" cols="12" sm="3" xsm="12">
                    <v-btn
                      x-large
                      block
                      :disabled="!valid"
                      color="success"
                      type="submit"
                    >
                      Update
                    </v-btn>
                  </v-col>
                </v-row>
              </v-form>
            </v-card-text>
          </v-card>
        </v-tab-item>
        <v-tab-item>
          <v-card class="px-4">
            <!-- <v-card-text>
              <v-form ref="registerForm" v-model="valid" lazy-validation>
                <v-row>
                  <v-col cols="12" sm="6" md="6">
                    <v-text-field
                      v-model="firstName"
                      :rules="[rules.required]"
                      label="First Name"
                      maxlength="20"
                      required
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="6">
                    <v-text-field
                      v-model="lastName"
                      :rules="[rules.required]"
                      label="Last Name"
                      maxlength="20"
                      required
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      v-model="email"
                      :rules="emailRules"
                      label="E-mail"
                      required
                    ></v-text-field>
                  </v-col>
                  <v-col cols="6">
                    <v-text-field
                      v-model="username"
                      :rules="[rules.required]"
                      label="Username"
                      required
                    ></v-text-field>
                  </v-col>
                  <v-col cols="6">
                    <v-text-field
                      v-model="phone"
                      :rules="phoneRules"
                      label="Phone"
                      required
                    ></v-text-field>
                  </v-col>
                  <v-col cols="6">
                    <v-text-field
                      v-model="password"
                      :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                      :rules="[rules.required, rules.min]"
                      :type="show1 ? 'text' : 'password'"
                      name="input-10-1"
                      label="Password"
                      hint="At least 8 characters"
                      counter
                      @click:append="show1 = !show1"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="6">
                    <v-text-field
                      block
                      v-model="verify"
                      :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                      :rules="[rules.required, passwordMatch]"
                      :type="show1 ? 'text' : 'password'"
                      name="input-10-1"
                      label="Confirm Password"
                      counter
                      @click:append="show1 = !show1"
                      @keyup.enter="submitLogin"
                    ></v-text-field>
                  </v-col>
                  <v-spacer></v-spacer>
                  <v-col class="d-flex ml-auto" cols="12" sm="3" xsm="12">
                    <v-btn
                      x-large
                      block
                      :disabled="!valid"
                      color="success"
                      @click="submitRegister"
                      >Register</v-btn
                    >
                  </v-col>
                </v-row>
              </v-form>
            </v-card-text> -->
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
    // const announcementTemplate = {
    //   title: "",
    //   description: "",
    //   startDate: "",
    //   endDate: "",
    //   ownerId: this.user.id,
    //   petId: "",
    // };
    return {
      active: true,
      tab: 0,
      tabs: [
        { name: "Announcement", icon: "mdi-message-alert" },
        { name: "Offers", icon: "mdi-account-plus" },
      ],
      valid: false,
      rules: {
        required: (value) => !!value || "Required.",
        min: (v) => (v && v.length >= 4) || "Min 4 characters",
        text: [(val) => (val || "").length > 0 || "This field is required"],
      },
      pets: [],
      selectLoading: true,
      newAnnouncement: { ...this.announcement },
    };
  },
  async mounted() {
    const result = await axios.get(
      `${cfg.BACKEND_ADDR}/owners/${this.user.id}/pets`
    );
    result.data.forEach((pet) => {
      this.pets.push({
        text: `${pet.name}, ${pet.sex} (${pet.age}yrs)`,
        value: pet.id,
        disabled: false,
      });
    });
    this.selectLoading = false;
  },
  methods: {
    cancel() {
      this.$emit("close");
    },
    remove() {
      this.$emit("submit-remove", this.announcement);
    },
    submit() {
      if (this.$refs.addForm.validate()) {
        this.$emit("submit-update", this.newAnnouncement);
      }
    },
  },
};
</script>
