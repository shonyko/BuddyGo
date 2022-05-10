<template>
  <v-app>
    <div class="card-wrapper">
      <v-card
        elevation="2"
        max-width="344"
        outlined
        v-for="pet in pets"
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

          <v-list-item-avatar tile size="80" color="grey"
            ><img
              src="https://p1-tt-ipv6.byteimg.com/origin/pgc-image/f6a0dd2ce1c943ae993d716767184ca1.jpg"
          /></v-list-item-avatar>
        </v-list-item>

        <v-card-actions class="float-right">
          <v-tooltip bottom color="primary">
            <template v-slot:activator="{ on, attrs }">
              <v-btn
                color="red"
                small
                fab
                outlined
                rounded
                v-bind="attrs"
                v-on="on"
                @click="remove(pet)"
              >
                <v-icon>mdi-trash-can</v-icon>
              </v-btn>
            </template>
            <span>Delete pet!</span>
          </v-tooltip>
          <v-tooltip bottom color="primary">
            <template v-slot:activator="{ on, attrs }">
              <v-btn
                color="amber"
                small
                fab
                outlined
                rounded
                v-bind="attrs"
                v-on="on"
                class="ml-1"
                @click="
                  selectedPet = pet;
                  editPet = true;
                "
              >
                <v-icon>mdi-pencil</v-icon>
              </v-btn>
            </template>
            <span>Update pet!</span>
          </v-tooltip>
        </v-card-actions>
      </v-card>
    </div>
    <AddPetDialog v-if="addPet" :user="user" @submit-add="add" />
    <EditPetDialog v-if="editPet" :pet="selectedPet" @submit-edit="edit" />
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
          @click="addPet = true"
        >
          <v-icon>mdi-plus-thick</v-icon>
        </v-btn>
      </template>
      <span>Add pet!</span>
    </v-tooltip>
    <v-alert v-show="alertVisible" :type="alertType" dismissible>
      {{ alertMsg }}
    </v-alert>
  </v-app>
</template>

<script>
import axios from "axios";
import cfg from "@/config/config.js";
import AddPetDialog from "./AddPetDialog.vue";
import EditPetDialog from "./EditPetDialog.vue";

export default {
  components: {
    AddPetDialog,
    EditPetDialog,
  },
  props: ["user"],
  data() {
    return {
      pets: [],
      tab: 0,
      edit_tabs: [{ name: "Edit", icon: "mdi-account" }],
      addPet: false,
      editPet: false,
      selectedPet: null,
      alertVisible: false,
      alertType: "error",
      alertMsg: "",
    };
  },
  async mounted() {
    await this.updatePets();
  },
  methods: {
    async updatePets() {
      const result = await axios.get(
        `${cfg.BACKEND_ADDR}/owners/${this.user.id}/pets`
      );
      this.pets = result.data;
      console.log(result);
    },
    async add(pet) {
      if (pet == null) {
        this.addPet = false;
        return;
      }

      try {
        await axios.post(`${cfg.BACKEND_ADDR}/pets`, pet);
        await this.updatePets();
        this.addPet = false;
        this.alert("Adaugat cu succes!", "success");
      } catch (e) {
        console.log(e);
        this.alert("Oops! A aparut o eroare!", "error");
      }
    },
    async edit(pet) {
      if (pet == null) {
        this.editPet = false;
        return;
      }

      try {
        await axios.put(`${cfg.BACKEND_ADDR}/pets/${pet.id}`, pet);
        await this.updatePets();
        this.editPet = false;
        this.alert("Modificat cu succes!", "success");
      } catch (e) {
        console.log(e);
        this.alert("Oops! A aparut o eroare!", "error");
      }
    },
    async remove(pet) {
      if (pet == null) {
        return;
      }

      try {
        await axios.delete(`${cfg.BACKEND_ADDR}/pets/${pet.id}`);
        await this.updatePets();
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
