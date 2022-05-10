<template>
  <v-app>
    <v-app-bar
      app
      color="primary"
      dark
      class="d-flex align-center justify-center"
    >
      <div class="d-flex align-center justify-center">
        <v-img
          alt="BuddyGo Logo"
          class="shrink mr-2"
          contain
          src="@/assets/BuddyGoLogo.png"
          transition="scale-transition"
          width="100"
        />

        <v-toolbar-title class="ml-n6 text-h4">BuddyGo</v-toolbar-title>
      </div>

      <v-spacer></v-spacer>
    </v-app-bar>

    <v-main>
      <v-dialog v-model="dialog" persistent max-width="600px" min-width="360px">
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
                  <v-form ref="loginForm" v-model="valid" lazy-validation>
                    <v-row>
                      <v-col cols="12">
                        <v-text-field
                          v-model="loginUsername"
                          :rules="[rules.required]"
                          label="Username"
                          required
                        ></v-text-field>
                      </v-col>
                      <v-col cols="12">
                        <v-text-field
                          v-model="loginPassword"
                          :append-icon="show1 ? 'eye' : 'eye-off'"
                          :rules="[rules.required, rules.min]"
                          :type="show1 ? 'text' : 'password'"
                          name="input-10-1"
                          label="Password"
                          hint="At least 8 characters"
                          counter
                          @click:append="show1 = !show1"
                        ></v-text-field>
                      </v-col>
                      <v-col class="d-flex" cols="12" sm="6" xsm="12"> </v-col>
                      <v-spacer></v-spacer>
                      <v-col class="d-flex" cols="12" sm="3" xsm="12" align-end>
                        <v-btn
                          x-large
                          block
                          :disabled="!valid"
                          color="success"
                          @click="submitLogin"
                        >
                          Login
                        </v-btn>
                      </v-col>
                    </v-row>
                  </v-form>
                </v-card-text>
              </v-card>
            </v-tab-item>
            <v-tab-item>
              <v-card class="px-4">
                <v-card-text>
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
                          :rules="[rules.required]"
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
                </v-card-text>
              </v-card>
            </v-tab-item>
          </v-tabs>
        </div>
      </v-dialog>
      <v-alert v-show="alertVisible" type="error" dismissible>
        {{ alertMsg }}
      </v-alert>
    </v-main>
  </v-app>
</template>

<script>
import axios from "axios";
import cfg from "@/config/config.js";

export default {
  name: "LoginRegisterView",
  computed: {
    passwordMatch() {
      return () => this.password === this.verify || "Password must match";
    },
  },
  mounted() {
    const user = JSON.parse(window.localStorage.getItem("user"));
    if (user != null) {
      this.$router.push({ name: "home" });
      return;
    }
  },
  methods: {
    async submitLogin() {
      if (this.$refs.loginForm.validate()) {
        const authData = {
          username: this.loginUsername,
          password: this.loginPassword,
        };
        try {
          var result = await axios.post(`${cfg.BACKEND_ADDR}/account/login`, {
            authData,
          });
          window.localStorage.setItem("user", JSON.stringify(result.data));
          window.localStorage.setItem("authData", JSON.stringify(authData));
          this.$router.push({ name: "home" });
        } catch (e) {
          console.log(e);
          this.alertMsg = "Username or password incorrect!";
          this.alertVisible = true;
          setTimeout(() => (this.alertVisible = false), 2000);
        }
      }
    },
    async submitRegister() {
      if (this.$refs.registerForm.validate()) {
        const authData = {
          username: this.username,
          password: this.password,
        };
        try {
          var result = await axios.post(
            `${cfg.BACKEND_ADDR}/account/register`,
            {
              authData,
              Name: `${this.lastName} ${this.firstName}`,
              PhoneNumber: this.phone,
              Email: this.email,
            }
          );
          window.localStorage.setItem("user", JSON.stringify(result.data));
          window.localStorage.setItem("authData", JSON.stringify(authData));
          this.$router.push({ name: "home" });
        } catch (e) {
          console.log(e);
          this.alertMsg = "Oops! There was an error.";
          this.alertVisible = true;
          setTimeout(() => (this.alertVisible = false), 2000);
        }
      }
    },
    // validate() {
    //   if (this.$refs.loginForm.validate()) {
    //     // submit form to server/API here...
    //   }
    // },
    reset() {
      this.$refs.form.reset();
    },
    resetValidation() {
      this.$refs.form.resetValidation();
    },
  },
  data: () => ({
    dialog: true,
    tab: 0,
    tabs: [
      { name: "Login", icon: "mdi-account" },
      { name: "Register", icon: "mdi-account-outline" },
    ],
    alertVisible: false,
    alertMsg: "",
    valid: true,
    firstName: "",
    lastName: "",
    email: "",
    username: "",
    phone: "",
    password: "",
    verify: "",
    loginPassword: "",
    loginUsername: "",
    loginEmailRules: [
      (v) => !!v || "Required",
      (v) => /.+@.+\..+/.test(v) || "E-mail must be valid",
    ],
    emailRules: [
      (v) => !!v || "Required",
      (v) => /.+@.+\..+/.test(v) || "E-mail must be valid",
    ],

    show1: false,
    rules: {
      required: (value) => !!value || "Required.",
      min: (v) => (v && v.length >= 4) || "Min 4 characters",
    },
  }),
};
</script>

<style scoped>
.v-alert {
  position: fixed;
  right: 1%;
  bottom: 15px;
  margin: 0 auto;
  z-index: 1000;
}
</style>
