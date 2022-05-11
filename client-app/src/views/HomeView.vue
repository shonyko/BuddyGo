<template>
  <v-app id="inspire">
    <v-navigation-drawer
      app
      color="grey lighten-2"
      mini-variant
      v-model="navbar"
    >
      <v-list class="ma-0">
        <v-list-item-group
          v-model="tabId"
          mandatory
          class="d-flex align-center justify-center flex-column ma-0"
        >
          <v-list-item
            v-for="(tab, i) in tabs"
            :key="i"
            class="nav-item pl-0 pr-0 d-flex align-center justify-center"
            @click="setActiveTab(i)"
          >
            <!-- :color="`grey ${i === 0 ? 'darken' : 'lighten'}-1`"
                :size="i === 0 ? 36 : 20" -->
            <v-tooltip
              v-if="tab.validate(user)"
              right
              color="primary"
              class="ml-1"
            >
              <template v-slot:activator="{ on, attrs }">
                <v-icon
                  v-on="on"
                  v-bind="attrs"
                  :color="tabId != i ? 'grey darken-2' : ''"
                  size="36"
                  class="d-block text-center ma-auto py-3"
                >
                  {{ tab.icon }}
                </v-icon>
              </template>
              <span>{{ tab.tooltip }}</span>
            </v-tooltip>
          </v-list-item>
        </v-list-item-group>
      </v-list>

      <v-tooltip right color="primary">
        <template v-slot:activator="{ on, attrs }">
          <v-btn
            color="red"
            small
            fab
            outlined
            v-bind="attrs"
            v-on="on"
            @click="logout"
          >
            <v-icon>mdi-exit-to-app</v-icon>
          </v-btn>
        </template>
        <span>Log Out!</span>
      </v-tooltip>
    </v-navigation-drawer>

    <v-main>
      <template v-if="user">
        <AccountTypeDialog
          v-if="incompleteUser"
          :user="user"
          @update-user="updateUser"
        />
        <component
          :is="currentTab"
          v-else
          :user="user"
          @update-user="updateUser"
        ></component>
        <!-- <UserProfile v-else :user="user" @update-user="updateUser" /> -->
      </template>
      <template v-else>
        <div class="loading-center">
          <v-progress-circular
            indeterminate
            color="primary"
          ></v-progress-circular>

          <v-progress-circular indeterminate color="red"></v-progress-circular>

          <v-progress-circular
            indeterminate
            color="purple"
          ></v-progress-circular>

          <v-progress-circular
            indeterminate
            color="green"
          ></v-progress-circular>

          <v-progress-circular
            indeterminate
            color="amber"
          ></v-progress-circular>
        </div>
      </template>
    </v-main>
  </v-app>
</template>

<script>
import axios from "axios";
import cfg from "@/config/config.js";
import AccountTypeDialog from "@/components/AccountTypeDialog.vue";
import UserProfile from "@/components/UserProfile.vue";
import ManagePets from "@/components/ManagePets.vue";

export default {
  name: "HomeView",
  components: {
    AccountTypeDialog,
    UserProfile,
    ManagePets,
  },
  data: () => ({
    user: null,
    tabId: 0,
    tabs: [
      {
        icon: "mdi-account-circle",
        name: "UserProfile",
        tooltip: "User profile",
        validate: () => true,
      },
      {
        icon: "mdi-paw",
        name: "ManagePets",
        tooltip: "Manage your pets",
        validate: (user) => user?.isOwner,
      },
    ],
    rules: {
      required: (value) => !!value || "Required.",
      min: (v) => (v && v.length >= 4) || "Min 4 characters",
    },
    cfg,
    navbar: true,
  }),
  async mounted() {
    let user = JSON.parse(window.localStorage.getItem("user"));
    console.log(user);
    if (user == null) {
      this.$router.push({ name: "login" });
      return;
    }

    await this.updateUser(user);
  },
  computed: {
    incompleteUser() {
      return this.user.incomplete;
    },
    currentTab() {
      return this.tabs[this.tabId].name;
    },
  },
  methods: {
    logout() {
      window.localStorage.setItem("user", JSON.stringify(null));
      this.$router.push({ name: "login" });
    },
    async updateUser(user) {
      let controller;
      if (user.incomplete) controller = "iusers";
      if (user.isOwner) controller = "owners";
      if (user.isSitter) controller = "sitters";

      const result = await axios.get(
        `${cfg.BACKEND_ADDR}/${controller}/${user.id}`
      );
      user = {
        authData: user.authData,
        ...result.data,
      };
      window.localStorage.setItem("user", JSON.stringify(user));

      this.user = user;
      this.pets = user.pets;
    },
    setActiveTab(index) {
      this.tabId = this.tabs[index].name;
    },
  },
};
</script>

<style>
/* .v-navigation-drawer {
  border: 10px solid red;
} */

.v-navigation-drawer__content {
  display: flex;
  flex-direction: column;
}

.v-navigation-drawer__content > *:first-child {
  margin-top: 1rem;
  /* margin-bottom: 15px; */
  margin-left: auto;
  margin-right: auto;
}

.v-navigation-drawer__content > *:last-child {
  margin-top: auto;
  margin-bottom: 15px;
  margin-left: auto;
  margin-right: auto;
}
.card-wrapper {
  display: flex;
  width: 100%;
  height: 100%;
  gap: 1rem;
  padding: 1rem;
  align-items: flex-start;
}
.v-alert {
  position: fixed;
  right: 1%;
  bottom: 15px;
  margin: 0 auto;
  z-index: 1000;
}

.nav-item {
  padding: 0;
  width: 100%;
  height: 100%;
}

.nav-item:hover {
  background-color: lightgray;
}

.theme--light.v-list-item.v-list-item--active {
  color: hotpink;
}

.loading-center {
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>
