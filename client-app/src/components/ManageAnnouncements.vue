<template>
  <v-app>
    <div class="card-wrapper">
      <v-hover v-for="a in announcements" :key="a.id">
        <template v-slot:default="{ hover }">
          <v-card max-width="344">
            <v-img
              src="https://cdn.vuetifyjs.com/images/cards/forest-art.jpg"
            ></v-img>

            <v-card-text>
              <h2 class="text-h6 primary--text">{{ a.title }}</h2>
              {{ a.description }}
            </v-card-text>

            <v-card-title>
              <!-- <v-rating
                :value="4"
                dense
                color="orange"
                background-color="orange"
                hover
                class="mr-2"
              ></v-rating> -->
              <span class="font-italic text-subtitle-2">
                {{ moment(a.startDate).format("YYYY-MM-DD HH:mm") }}
                <span class="font-weight-light mx-2">to</span>
                {{ moment(a.endDate).format("YYYY-MM-DD HH:mm") }}
              </span>
            </v-card-title>

            <v-fade-transition>
              <v-overlay v-if="hover" absolute color="#036358">
                <v-btn @click="seeDetails(a)">See more info</v-btn>
              </v-overlay>
            </v-fade-transition>
          </v-card>
        </template>
      </v-hover>
    </div>
    <AddAnnouncementDialog
      v-if="addAnnouncement"
      :user="user"
      @submit-add="add"
    />
    <AnnouncementDetailsDialog
      v-if="seeAnnouncementDetails"
      :user="user"
      :announcement="selectedAnnouncement"
      @close="seeAnnouncementDetails = false"
      @submit-update="update"
      @submit-remove="remove"
    />
    <v-tooltip top color="primary">
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          color="green"
          small
          fab
          outlined
          v-bind="attrs"
          v-on="on"
          class="add-btn"
          @click="addAnnouncement = true"
        >
          <v-icon>mdi-plus-thick</v-icon>
        </v-btn>
      </template>
      <span>Announce!</span>
    </v-tooltip>
    <v-alert v-show="alertVisible" :type="alertType" dismissible>
      {{ alertMsg }}
    </v-alert>
  </v-app>
</template>

<script>
import axios from "axios";
import cfg from "@/config/config.js";
import moment from "moment";
import AddAnnouncementDialog from "./AddAnnouncementDialog.vue";
import AnnouncementDetailsDialog from "./AnnouncementDetailsDialog.vue";

export default {
  components: {
    AddAnnouncementDialog,
    AnnouncementDetailsDialog,
  },
  props: ["user"],
  data() {
    return {
      announcements: [],
      tab: 0,
      edit_tabs: [{ name: "Edit", icon: "mdi-account" }],
      addAnnouncement: false,
      //   editAnnouncement: false,
      alertVisible: false,
      alertType: "error",
      alertMsg: "",
      moment: moment,
      seeAnnouncementDetails: false,
      selectedAnnouncement: null,
    };
  },
  async mounted() {
    await this.updateList();
  },
  methods: {
    async updateList() {
      const result = await axios.get(
        `${cfg.BACKEND_ADDR}/owners/${this.user.id}/announcements`
      );
      this.announcements = result.data;
      console.log(result);
    },
    async add(announcement) {
      if (announcement == null) {
        this.addAnnouncement = false;
        return;
      }

      try {
        await axios.post(`${cfg.BACKEND_ADDR}/announcements`, announcement);
        await this.updateList();
        this.addAnnouncement = false;
        this.alert("Adaugat cu succes!", "success");
      } catch (e) {
        console.log(e);
        this.alert("Oops! A aparut o eroare!", "error");
      }
    },
    async update(a) {
      if (a == null) {
        this.seeAnnouncementDetails = false;
        return;
      }

      try {
        await axios.put(`${cfg.BACKEND_ADDR}/announcements/${a.id}`, a);
        this.seeAnnouncementDetails = false;
        await this.updateList();
        this.alert("Modificat cu succes!", "success");
      } catch (e) {
        console.log(e);
        this.alert("Oops! A aparut o eroare!", "error");
      }
    },
    async remove(announcement) {
      if (announcement == null) {
        return;
      }

      try {
        await axios.delete(
          `${cfg.BACKEND_ADDR}/announcements/${announcement.id}`
        );
        this.seeAnnouncementDetails = false;
        await this.updateList();
        this.alert("Sters cu succes!", "success");
      } catch (e) {
        console.log(e);
        this.alert("Oops! A aparut o eroare!", "error");
      }
    },
    alert(msg, type) {
      this.alertMsg = msg;
      this.alertType = type;
      this.alertVisible = true;
      setTimeout(() => (this.alertVisible = false), 2000);
    },
    seeDetails(a) {
      this.selectedAnnouncement = a;
      this.seeAnnouncementDetails = true;
    },
  },
};
</script>

<style>
.add-btn {
  position: fixed;
  right: 2rem;
  bottom: 15px;
  margin: 0 auto;
  z-index: 100;
}
</style>
