<template>
  <v-app>
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
                        :disabled="!valid || hasSitter"
                        color="success"
                        type="submit"
                      >
                        {{ !hasSitter ? "Update" : "Completed" }}
                      </v-btn>
                    </v-col>
                  </v-row>
                </v-form>
              </v-card-text>
            </v-card>
          </v-tab-item>
          <v-tab-item v-if="!hasSitter">
            <v-card
              v-for="(offer, i) in offers"
              :key="offer.id"
              class="mx-auto elevation-20"
              color="light-green lighten-2"
              dark
              style="max-width: 400px"
            >
              <v-row justify="space-between">
                <v-col cols="8">
                  <v-card-title>
                    <div>
                      <div class="text-h5">{{ sitters[i].name }}</div>
                      <div>{{ sitters[i].description }}</div>
                    </div>
                  </v-card-title>
                </v-col>
                <v-tooltip bottom color="primary">
                  <template v-slot:activator="{ on, attrs }">
                    <v-img
                      class="shrink ma-2 img-hover"
                      contain
                      height="125px"
                      src="https://media.istockphoto.com/vectors/boy-hug-dog-vector-id1249679431?k=20&m=1249679431&s=612x612&w=0&h=Jci7cPM86W59yWd59Bz6CAR15aBHszZE2IHtm4DL9h4="
                      style="flex-basis: 125px"
                      v-on="on"
                      v-bind="attrs"
                      @click="openProfile(sitters[i])"
                    ></v-img>
                  </template>
                  <span>Click for more details!</span>
                </v-tooltip>
              </v-row>
              <v-divider dark></v-divider>
              <v-card-actions class="pa-4">
                <v-tooltip bottom color="primary">
                  <template v-slot:activator="{ on, attrs }">
                    <v-btn
                      color="purple darken-1"
                      small
                      fab
                      outlined
                      rounded
                      v-bind="attrs"
                      v-on="on"
                      class="ml-1"
                      @click="accept(offer)"
                    >
                      <v-icon dark>mdi-thumb-up</v-icon>
                    </v-btn>
                  </template>
                  <span>Hire this person!</span>
                </v-tooltip>
                <v-spacer></v-spacer>
                <span class="grey--text text--lighten-2 text-caption mr-2">
                  ({{ 4.5 }})
                </span>
                <!-- v-model="rating" -->
                <v-rating
                  background-color="white"
                  color="yellow accent-4"
                  dense
                  half-increments
                  hover
                  size="18"
                  readonly
                ></v-rating>
              </v-card-actions>
            </v-card>
          </v-tab-item>
          <v-tab-item v-else>
            <v-card
              class="mx-auto elevation-20"
              color="light-green lighten-2"
              dark
              style="max-width: 400px"
            >
              <v-row justify="space-between">
                <v-col cols="8">
                  <v-card-title>
                    <div>
                      <div class="text-h5">{{ acceptedSitter.name }}</div>
                      <div>{{ acceptedSitter.description }}</div>
                    </div>
                  </v-card-title>
                </v-col>
                <v-tooltip bottom color="primary">
                  <template v-slot:activator="{ on, attrs }">
                    <v-img
                      class="shrink ma-2 img-hover"
                      contain
                      height="125px"
                      src="https://media.istockphoto.com/vectors/boy-hug-dog-vector-id1249679431?k=20&m=1249679431&s=612x612&w=0&h=Jci7cPM86W59yWd59Bz6CAR15aBHszZE2IHtm4DL9h4="
                      style="flex-basis: 125px"
                      v-on="on"
                      v-bind="attrs"
                      @click="openProfile(acceptedSitter)"
                    ></v-img>
                  </template>
                  <span>Click for more details!</span>
                </v-tooltip>
              </v-row>
              <v-divider dark></v-divider>
              <v-card-actions class="pa-4">
                Don't forget to rate!
                <v-spacer></v-spacer>
                <span class="grey--text text--lighten-2 text-caption mr-2">
                  ({{ 4.5 }})
                </span>
                <!-- v-model="rating" -->
                <v-rating
                  background-color="white"
                  color="yellow accent-4"
                  dense
                  half-increments
                  hover
                  size="18"
                  readonly
                ></v-rating>
              </v-card-actions>
            </v-card>
          </v-tab-item>
        </v-tabs>
      </div>
    </v-dialog>
    <SitterProfileDialog
      v-if="showProfile"
      :sitter="currentSitter"
      @close="showProfile = false"
    />
  </v-app>
</template>

<script>
import axios from "axios";
import cfg from "@/config/config.js";
// import moment from "moment";
import DateTimePicker from "./DateTimePicker.vue";
import SitterProfileDialog from "./SitterProfileDialog.vue";

export default {
  components: {
    DateTimePicker,
    SitterProfileDialog,
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
      offers: [],
      sitters: [],
      showProfile: false,
      currentSitter: null,
    };
  },
  async mounted() {
    let result = await axios.get(
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

    result = await axios.get(
      `${cfg.BACKEND_ADDR}/announcements/${this.announcement.id}/offers`
    );
    this.offers = result.data;
    this.sitters = [];
    this.offers.forEach(async (offer) => {
      const res = await axios.get(
        `${cfg.BACKEND_ADDR}/sitters/${offer.sitterId}`
      );
      this.sitters.push(res.data);
    });
    console.log(this.offers);
    console.log(this.sitters);
    console.log(this.hasSitter);
    const offer = this.offers.filter(
      (x) => x.id == this.announcement.offerId
    )[0];
    console.log(offer);
    console.log(this.sitters.filter((x) => x.id == offer.sitterId)[0]);
    console.log(this.user);
  },
  computed: {
    acceptedSitter() {
      const offer = this.offers.filter(
        (x) => x.id == this.announcement.offerId
      )[0];
      return this.sitters.filter((x) => x.id == offer.sitterId)[0];
    },
    hasSitter() {
      return this.announcement.offerId != null;
    },
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
    openProfile(sitter) {
      this.currentSitter = sitter;
      this.showProfile = true;
    },
    accept(offer) {
      this.$emit("accept", offer);
    },
  },
};
</script>

<style>
.img-hover:hover {
  cursor: pointer;
}
</style>
