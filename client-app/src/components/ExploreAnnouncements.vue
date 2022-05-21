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
    <SitterAnnouncementsDialog
      v-if="seeAnnouncementDetails"
      :user="user"
      :announcement="selectedAnnouncement"
      @close="seeAnnouncementDetails = false"
      @submit-apply="apply"
    />
    <v-alert v-show="alertVisible" :type="alertType" dismissible>
      {{ alertMsg }}
    </v-alert>
  </v-app>
</template>

<script>
import axios from "axios";
import cfg from "@/config/config.js";
import moment from "moment";
import SitterAnnouncementsDialog from "./SitterAnnouncementsDialog.vue";

export default {
  components: {
    SitterAnnouncementsDialog,
  },
  props: ["user", "socket"],
  data() {
    return {
      announcements: [],
      tab: 0,
      edit_tabs: [{ name: "Edit", icon: "mdi-account" }],
      addAnnouncement: false,
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
      const result = await axios.get(`${cfg.BACKEND_ADDR}/announcements/`);
      this.announcements = result.data;
      console.log(result);
    },
    async apply(a) {
      if (a == null) {
        this.seeAnnouncementDetails = false;
        return;
      }

      try {
        await axios.post(`${cfg.BACKEND_ADDR}/offers/`, {
          sitterId: this.user.id,
          announcementId: a.id,
        });
        await this.updateList();
        this.seeAnnouncementDetails = false;
        this.alert("Adaugat cu succes!", "success");
        await this.socket.invoke("SendNotification", JSON.stringify(a));
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
