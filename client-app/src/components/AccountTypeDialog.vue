<template>
  <v-dialog v-model="open" persistent max-width="600px" min-width="360px">
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
              <v-form>
                <v-row class="d-flex justify-space-around">
                  <v-col class="d-flex" cols="12" sm="3" xsm="12">
                    <v-btn
                      x-large
                      block
                      color="success"
                      @click="submitAccountType(cfg.ACC_TYPE_OWNER)"
                    >
                      Pet Owner!
                    </v-btn>
                  </v-col>
                  <v-col class="d-flex" cols="12" sm="3" xsm="12">
                    <v-btn
                      x-large
                      block
                      color="success"
                      @click="submitAccountType(cfg.ACC_TYPE_SITTER)"
                    >
                      Pet Sitter!
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
import axios from "axios";
import cfg from "@/config/config.js";

export default {
  name: "AccountTypeDialog",
  data: () => ({
    cfg,
    tab: 0,
    tabs: [{ name: "Choose your account type!", icon: "mdi-account" }],
    open: true,
  }),
  methods: {
    async submitAccountType(type) {
      const result = await axios.post(`${cfg.BACKEND_ADDR}/account/type`, {
        id: this.user.id,
        type,
      });

      const user = result.data;
      console.log(user);
      this.$emit("update-user", user);
    },
  },
};
</script>
