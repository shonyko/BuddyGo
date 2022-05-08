<template>
  <v-app id="inspire">
    <v-navigation-drawer app class="pt-4" color="grey lighten-3" mini-variant>
      <v-avatar
        v-for="n in 6"
        :key="n"
        :color="`grey ${n === 1 ? 'darken' : 'lighten'}-1`"
        :size="n === 1 ? 36 : 20"
        class="d-block text-center mx-auto mb-9"
      ></v-avatar>
      <v-btn outlined color="red" small fab @click="logout">Exit</v-btn>
    </v-navigation-drawer>

    <v-main>
      <div class="card-wrapper">
        <v-card
          elevation="2"
          max-width="344"
          outlined
          v-for="(pet, i) in pets"
          :key="pet.id"
        >
          <v-list-item three-line>
            <v-list-item-content>
              <div class="text-overline mb-4">
                {{
                  `${pet.sex == "M" ? "Male" : "Female"}, ${pet.age}, ${
                    pet.weight
                  }kg`
                }}
              </div>
              <v-list-item-title class="text-h5 mb-1">
                {{ pet.name }}
              </v-list-item-title>
              <v-list-item-subtitle>{{ pet.description }}</v-list-item-subtitle>
            </v-list-item-content>

            <v-list-item-avatar
              tile
              size="80"
              color="grey"
            ></v-list-item-avatar>
          </v-list-item>

          <v-card-actions class="float-right">
            <v-btn
              outlined
              rounded
              text
              fab
              small
              color="red"
              @click="submitDelete(pet)"
            >
              Del
            </v-btn>
            <v-btn
              outlined
              rounded
              text
              fab
              small
              color="yellow"
              @click="edit(pet, i)"
            >
              Edit
            </v-btn>
          </v-card-actions>
        </v-card>
      </div>
      <v-dialog
        v-if="editing"
        v-model="editing"
        persistent
        max-width="600px"
        min-width="360px"
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
                  <v-form ref="editForm" v-model="valid" lazy-validation>
                    <v-row>
                      <v-col cols="6" sm="6" md="6">
                        <v-text-field
                          v-model="currentPet.name"
                          :rules="[rules.required]"
                          label="Name"
                          maxlength="20"
                          required
                        ></v-text-field>
                      </v-col>
                      <v-col cols="6" sm="6" md="6">
                        <v-text-field
                          v-model="currentPet.age"
                          :rules="[rules.required]"
                          label="Age"
                          maxlength="20"
                          required
                        ></v-text-field>
                      </v-col>
                      <v-col cols="6">
                        <v-text-field
                          v-model="currentPet.sex"
                          :rules="[rules.required]"
                          label="Sex"
                          required
                        ></v-text-field>
                      </v-col>
                      <v-col cols="6">
                        <v-text-field
                          v-model="currentPet.weight"
                          :rules="[rules.required]"
                          label="Weight"
                          required
                        ></v-text-field>
                      </v-col>
                      <v-col cols="12">
                        <v-text-field
                          v-model="currentPet.description"
                          label="Description"
                          required
                        ></v-text-field>
                      </v-col>
                      <v-spacer></v-spacer>
                      <v-col class="d-flex ml-auto" cols="12" sm="3" xsm="12">
                        <v-btn x-large block @click="cancel">Close</v-btn>
                      </v-col>
                      <v-col class="d-flex" cols="12" sm="3" xsm="12">
                        <v-btn
                          x-large
                          block
                          :disabled="!valid"
                          color="success"
                          @click="submitEdit"
                          >Change</v-btn
                        >
                      </v-col>
                    </v-row>
                  </v-form>
                </v-card-text>
              </v-card>
            </v-tab-item>
          </v-tabs>
        </div>
      </v-dialog>
      <v-dialog
        v-if="adding"
        v-model="adding"
        persistent
        max-width="600px"
        min-width="360px"
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
            <v-tab v-for="i in add_tabs" :key="i.name">
              <v-icon large>{{ i.icon }}</v-icon>
              <div class="caption py-1">{{ i.name }}</div>
            </v-tab>
            <v-tab-item>
              <v-card class="px-4">
                <v-card-text>
                  <v-form ref="addForm" v-model="valid" lazy-validation>
                    <v-row>
                      <v-col cols="6" sm="6" md="6">
                        <v-text-field
                          v-model="newPet.name"
                          :rules="[rules.required]"
                          label="Name"
                          maxlength="20"
                          required
                        ></v-text-field>
                      </v-col>
                      <v-col cols="6" sm="6" md="6">
                        <v-text-field
                          v-model="newPet.age"
                          :rules="[rules.required]"
                          label="Age"
                          maxlength="20"
                          required
                        ></v-text-field>
                      </v-col>
                      <v-col cols="6">
                        <v-text-field
                          v-model="newPet.sex"
                          :rules="[rules.required]"
                          label="Sex"
                          required
                        ></v-text-field>
                      </v-col>
                      <v-col cols="6">
                        <v-text-field
                          v-model="newPet.weight"
                          :rules="[rules.required]"
                          label="Weight"
                          required
                        ></v-text-field>
                      </v-col>
                      <v-col cols="12">
                        <v-text-field
                          v-model="newPet.description"
                          label="Description"
                          required
                        ></v-text-field>
                      </v-col>
                      <v-spacer></v-spacer>
                      <v-col class="d-flex ml-auto" cols="12" sm="3" xsm="12">
                        <v-btn x-large block @click="cancel">Close</v-btn>
                      </v-col>
                      <v-col class="d-flex" cols="12" sm="3" xsm="12">
                        <v-btn
                          x-large
                          block
                          :disabled="!valid"
                          color="success"
                          @click="submitAdd"
                          >Add</v-btn
                        >
                      </v-col>
                    </v-row>
                  </v-form>
                </v-card-text>
              </v-card>
            </v-tab-item>
          </v-tabs>
        </div>
      </v-dialog>
      <v-alert v-show="alertVisible" type="error" dismissible>
        {{ alertMsg }}
      </v-alert>
      <v-btn class="add-btn" outlined color="green" small fab @click="add"
        >Add</v-btn
      >
    </v-main>
  </v-app>
</template>

<script>
import axios from "axios";
import cfg from "@/config/config.js";

export default {
  name: "HomeView",
  data: () => ({
    user: null,
    pets: [],
    tab: 0,
    tabs: [{ name: "Edit", icon: "mdi-account" }],
    add_tabs: [{ name: "Add", icon: "mdi-account" }],
    editing: false,
    adding: false,
    newPet: null,
    currentPet: null,
    currentIndex: null,
    copyPet: null,
    rules: {
      required: (value) => !!value || "Required.",
      min: (v) => (v && v.length >= 4) || "Min 4 characters",
    },
    valid: true,
    alertVisible: false,
    alertMsg: "",
  }),
  async mounted() {
    let user = JSON.parse(window.localStorage.getItem("user"));
    console.log(user);
    if (user == null) {
      this.$router.push({ name: "login" });
      return;
    }

    const result = await axios.get(`${cfg.BACKEND_ADDR}/owners/${user.id}`);
    user = result.data;
    window.localStorage.setItem("user", JSON.stringify(user));

    this.user = user;
    this.pets = user.pets;
  },
  // computed: {
  //   currentPet() {
  //     return this.pets[this.currentIndex];
  //   },
  // },
  methods: {
    logout() {
      window.localStorage.setItem("user", JSON.stringify(null));
      this.$router.push({ name: "login" });
    },
    edit(pet, i) {
      this.copyPet = { ...pet };
      this.currentPet = pet;
      this.currentIndex = i;
      this.editing = true;
    },
    cancel() {
      this.editing = false;
      this.adding = false;
      if (this.currentIndex == null) return;
      this.pets[this.currentIndex] = this.copyPet;
      this.copyPet = null;
      this.currentPet = null;
      this.currentIndex = null;
    },
    async submitEdit() {
      if (this.$refs.editForm.validate()) {
        try {
          await axios.put(
            `${cfg.BACKEND_ADDR}/pets/${this.currentPet.id}`,
            this.currentPet
          );
          const owner = await axios.get(
            `${cfg.BACKEND_ADDR}/owners/${this.currentPet.ownerId}`
          );
          this.pets = owner.data.pets;
          this.editing = false;
          this.currentPet = null;
        } catch (e) {
          console.log(e);
          this.alertMsg = "Oops! A aparut o eroare!";
          this.alertVisible = true;
          setTimeout(() => (this.alertVisible = false), 2000);
        }
      }
    },
    add() {
      this.newPet = {
        name: "",
        sex: "",
        weight: "",
        age: "",
        description: "",
        ownerId: this.user.id,
      };
      this.adding = true;
    },
    async submitAdd() {
      if (this.$refs.addForm.validate()) {
        try {
          await axios.post(`${cfg.BACKEND_ADDR}/pets`, this.newPet);
          const owner = await axios.get(
            `${cfg.BACKEND_ADDR}/owners/${this.newPet.ownerId}`
          );
          this.pets = owner.data.pets;
          this.adding = false;
        } catch (e) {
          console.log(e);
          this.alertMsg = "Oops! A aparut o eroare!";
          this.alertVisible = true;
          setTimeout(() => (this.alertVisible = false), 2000);
        }
      }
    },
    async submitDelete(pet) {
      try {
        await axios.delete(`${cfg.BACKEND_ADDR}/pets/${pet.id}`);
        const owner = await axios.get(
          `${cfg.BACKEND_ADDR}/owners/${pet.ownerId}`
        );
        this.pets = owner.data.pets;
      } catch (e) {
        console.log(e);
        this.alertMsg = "Oops! A aparut o eroare!";
        this.alertVisible = true;
        setTimeout(() => (this.alertVisible = false), 2000);
      }
    },
    updateUser(user) {
      this.user = user;
      this.pets = this.user.pets;
    },
  },
};
</script>

<style>
.v-navigation-drawer__content {
  display: flex;
  flex-direction: column;
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
.v-alert,
.add-btn {
  position: fixed;
  right: 1%;
  bottom: 15px;
  margin: 0 auto;
  z-index: 1000;
}
</style>
