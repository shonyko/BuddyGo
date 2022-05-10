<template>
  <v-card flat>
    <v-snackbar v-model="snackbar" absolute top right color="success">
      <span>Registration successful!</span>
      <v-icon dark> mdi-checkbox-marked-circle </v-icon>
    </v-snackbar>
    <v-form ref="form" @submit.prevent="submit">
      <v-container fluid>
        <v-row>
          <v-col cols="12" sm="6">
            <v-text-field
              :value="authData.username"
              label="Username"
              readonly
            ></v-text-field>
          </v-col>
          <v-col cols="12" sm="6">
            <v-text-field
              v-model="authData.password"
              :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
              :rules="[passwordRules.required, passwordRules.min]"
              :type="showPassword ? 'text' : 'password'"
              name="input-10-1"
              label="Password"
              hint="At least 4 characters"
              counter
              @click:append="showPassword = !showPassword"
            >
            </v-text-field>
          </v-col>
          <v-col cols="12" sm="6">
            <v-text-field
              v-model="form.first"
              :rules="rules.name"
              color="purple darken-2"
              label="First name"
              required
              clearable
            ></v-text-field>
          </v-col>
          <v-col cols="12" sm="6">
            <v-text-field
              v-model="form.last"
              :rules="rules.name"
              color="purple darken-2"
              label="Last name"
              required
              clearable
            ></v-text-field>
          </v-col>

          <v-col cols="12">
            <v-textarea v-model="form.bio" color="teal" clearable>
              <template v-slot:label>
                <div>Bio <small>(optional)</small></div>
              </template>
            </v-textarea>
          </v-col>
          <v-col cols="12" sm="6">
            <v-select
              v-model="form.favoriteAnimal"
              :items="animals"
              :rules="rules.animal"
              color="pink"
              label="Favorite animal"
              required
            ></v-select>
          </v-col>
          <v-col cols="12" sm="6">
            <v-slider
              v-model="form.age"
              :rules="rules.age"
              color="orange"
              label="Age"
              hint="Be honest"
              min="1"
              max="100"
              thumb-label
            ></v-slider>
          </v-col>
          <v-col cols="12">
            <v-checkbox v-model="form.terms" color="green">
              <template v-slot:label>
                <div @click.stop="">
                  Do you accept the
                  <a href="#" @click.prevent="terms = true">terms</a>
                  and
                  <a href="#" @click.prevent="conditions = true">conditions?</a>
                </div>
              </template>
            </v-checkbox>
          </v-col>
        </v-row>
      </v-container>
      <v-card-actions>
        <v-btn text @click="resetForm"> Cancel </v-btn>
        <v-spacer></v-spacer>
        <v-btn :disabled="!formIsValid" text color="primary" type="submit">
          Register
        </v-btn>
      </v-card-actions>
    </v-form>
    <v-dialog v-model="terms" width="70%">
      <v-card>
        <v-card-title class="text-h6"> Terms </v-card-title>
        <v-card-text v-for="n in 5" :key="n">
          {{ content }}
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn text color="purple" @click="terms = false"> Ok </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <v-dialog v-model="conditions" width="70%">
      <v-card>
        <v-card-title class="text-h6"> Conditions </v-card-title>
        <v-card-text v-for="n in 5" :key="n">
          {{ content }}
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn text color="purple" @click="conditions = false"> Ok </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-card>
</template>

<script>
// import axios from "axios";
// import cfg from "@/config/config.js";

// export default {
//   name: "AccountTypeDialog",
//   data: () => ({
//     cfg,
//     tab: 0,
//     tabs: [{ name: "Choose your account type!", icon: "mdi-account" }],
//     open: true,
//   }),
//   methods: {
//     async submitAccountType(type) {
//       const result = await axios.post(`${cfg.BACKEND_ADDR}/account/type`, {
//         id: this.user.id,
//         type,
//       });

//       const user = result.data;
//       console.log(user);
//       this.$emit("updateUser", user);
//     },
//   },
// };
export default {
  props: ["user"],
  data() {
    const defaultForm = Object.freeze({
      first: "",
      last: "",
      bio: "",
      favoriteAnimal: "",
      age: null,
      terms: false,
    });

    const authData = JSON.parse(localStorage.getItem("authData"));
    // console.log(`${username} ${password}`);

    return {
      form: Object.assign({}, defaultForm),
      rules: {
        age: [(val) => val < 10 || `I don't believe you!`],
        animal: [(val) => (val || "").length > 0 || "This field is required"],
        name: [(val) => (val || "").length > 0 || "This field is required"],
      },
      animals: ["Dog", "Cat", "Rabbit", "Turtle", "Snake"],
      conditions: false,
      content:
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc.",
      snackbar: false,
      terms: false,
      defaultForm,
      showPassword: false,
      passwordRules: {
        required: (value) => !!value || "Required.",
        min: (v) => v.length >= 4 || "Min 4 characters",
      },
      authData,
    };
  },
  //   mounted() {
  //     this.authData = console.log(this.authData);
  //   },

  computed: {
    formIsValid() {
      return (
        this.form.first &&
        this.form.last &&
        this.form.favoriteAnimal &&
        this.form.terms
      );
    },
    firstName() {
      const names = this.user.name.split(" ");
      return names[names.length - 1];
    },
    lastName() {
      const names = this.user.name.split(" ");
      if (names.length <= 1) return "";
      return names[0];
    },
  },

  methods: {
    resetForm() {
      this.form = Object.assign({}, this.defaultForm);
      this.$refs.form.reset();
    },
    submit() {
      this.snackbar = true;
      this.resetForm();
    },
  },
};
</script>
