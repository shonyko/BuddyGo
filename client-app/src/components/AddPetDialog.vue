<template>
  <v-dialog
    v-model="active"
    persistent
    max-width="600px"
    min-width="360px"
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
              <!-- lazy-validation -->
              <v-form ref="addForm" v-model="valid" @submit.prevent="submit">
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
                  <v-col cols="6">
                    <v-text-field
                      v-model="newPet.weight"
                      :rules="[rules.required]"
                      label="Weight"
                      required
                    ></v-text-field>
                  </v-col>
                  <v-col cols="2">
                    <v-select
                      v-model="newPet.sex"
                      :items="sexes"
                      :rules="rules.text"
                      label="Sex"
                      required
                    ></v-select>
                  </v-col>
                  <v-col cols="10">
                    <v-slider
                      v-model="newPet.age"
                      color="orange"
                      label="Age"
                      hint="Be honest"
                      min="1"
                      max="100"
                      thumb-label
                      class="pt-6"
                    ></v-slider>
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
                      type="submit"
                    >
                      Add
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
export default {
  props: ["user"],
  data() {
    const petTemplate = {
      name: "",
      age: 0,
      sex: "M",
      weight: "",
      description: "",
      ownerId: this.user.id,
    };
    return {
      active: true,
      tab: 0,
      tabs: [{ name: "Add a new pet !", icon: "mdi-dog" }],
      valid: false,
      rules: {
        required: (value) => !!value || "Required.",
        min: (v) => (v && v.length >= 4) || "Min 4 characters",
        text: [(val) => (val || "").length > 0 || "This field is required"],
      },
      sexes: ["M", "F"],
      newPet: { ...petTemplate },
      petTemplate,
    };
  },
  methods: {
    cancel() {
      this.$emit("submit-add");
    },
    submit() {
      if (this.$refs.addForm.validate()) {
        this.$emit("submit-add", this.newPet);
      }
    },
  },
};
</script>
