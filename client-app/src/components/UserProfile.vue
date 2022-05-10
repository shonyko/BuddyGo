<template>
  <v-card flat>
    <v-form ref="form" v-model="formIsValid" @submit.prevent="submit">
      <v-container fluid>
        <v-row>
          <v-col cols="12" sm="6">
            <v-text-field
              :value="userModel.authData.username"
              label="Username"
              readonly
            ></v-text-field>
          </v-col>
          <v-col cols="12" sm="6">
            <v-text-field
              v-model="userModel.authData.password"
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
              v-model="userModel.name"
              :rules="rules.name"
              color="purple darken-2"
              label="Name"
              required
              clearable
            ></v-text-field>
          </v-col>
          <v-col cols="12" sm="6">
            <v-text-field
              :value="accountType"
              color="purple darken-2"
              label="Account Type"
              readonly
            ></v-text-field>
          </v-col>
          <v-col cols="12" sm="6">
            <v-text-field
              v-model="userModel.email"
              :rules="rules.email"
              color="purple darken-2"
              label="Email"
              required
              clearable
            ></v-text-field>
          </v-col>
          <v-col cols="12" sm="6">
            <v-text-field
              v-model="userModel.phoneNumber"
              :rules="rules.phone"
              color="purple darken-2"
              label="Phone Number"
              required
              clearable
            ></v-text-field>
          </v-col>
          <v-col cols="12" v-if="user.isSitter">
            <v-textarea v-model="userModel.description" color="teal" clearable>
              <template v-slot:label>
                <div>Description <small>(optional)</small></div>
              </template>
            </v-textarea>
          </v-col>
        </v-row>
      </v-container>
      <v-card-actions>
        <v-btn :disabled="!formIsValid" tile color="error" @click="resetForm">
          <v-icon left> mdi-restore </v-icon>
          Reset
        </v-btn>
        <v-spacer></v-spacer>
        <v-btn :disabled="!formIsValid" tile color="success" type="submit">
          <v-icon left> mdi-pencil </v-icon>
          Update
        </v-btn>
      </v-card-actions>
    </v-form>
  </v-card>
</template>

<script>
import axios from "axios";
import cfg from "@/config/config.js";

export default {
  props: ["user"],
  data() {
    return {
      rules: {
        name: [(val) => (val || "").length > 0 || "This field is required"],
        email: [
          (v) => !!v || "Required",
          (v) => /.+@.+\..+/.test(v) || "E-mail must be valid",
        ],
        phone: [
          (v) => !!v || "Required",
          (v) =>
            /[+]?[(]?[0-9]{3}[)]?[-\s.]?[0-9]{3}[-\s.]?[0-9]{4,6}/.test(v) ||
            "Phone number must be valid",
        ],
      },
      showPassword: false,
      formIsValid: true,
      passwordRules: {
        required: (value) => !!value || "Required.",
        min: (v) => v.length >= 4 || "Min 4 characters",
      },
      userModel: { ...this.user },
    };
  },
  mounted() {
    console.log(this.userModel);
  },

  computed: {
    accountType() {
      if (this.user.isSitter) return "Sitter";
      if (this.user.isOwner) return "Owner";
      return "Error";
    },
  },

  methods: {
    resetForm() {
      this.userModel = {
        ...this.user,
      };
    },
    async submit() {
      let controller = "";
      if (this.user.isOwner) controller = "owners";
      if (this.user.isSitter) controller = "sitters";
      await axios.put(
        `${cfg.BACKEND_ADDR}/${controller}/${this.userModel.id}`,
        this.userModel
      );
      this.$emit("update-user", this.userModel);
    },
  },
};
</script>
