<template>
  <v-dialog
    v-model="active"
    persistent
    max-width="375px"
    min-width="360px"
    scrollable
    @click:outside="cancel"
    @keydown.esc="cancel"
  >
    <v-card max-width="375" class="mx-auto">
      <v-img
        src="https://img.money.com/2021/12/News-Gen-Z-dog-owners-would-pay-for-pet-therapy.jpg"
        height="300px"
        dark
      >
        <v-row class="fill-height">
          <v-card-title>
            <v-btn dark icon color="primary" @click="cancel">
              <v-icon>mdi-chevron-left</v-icon>
            </v-btn>

            <v-spacer></v-spacer>

            <v-btn disabled dark icon class="mr-4" color="primary">
              <v-icon></v-icon>
            </v-btn>

            <v-btn disabled dark icon color="primary">
              <v-icon></v-icon>
            </v-btn>
            <v-btn disabled dark icon class="mr-4" color="primary">
              <v-icon></v-icon>
            </v-btn>
          </v-card-title>

          <v-spacer></v-spacer>

          <v-card-title class="white--text pl-12 pt-12">
            <div class="text-h4 pl-12 pt-12">{{ sitter.name }}</div>
          </v-card-title>
        </v-row>
      </v-img>

      <v-list two-line>
        <v-list-item>
          <v-list-item-icon>
            <v-icon color="indigo"> mdi-phone </v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ sitter.phoneNumber }}</v-list-item-title>
            <v-list-item-subtitle>Mobile</v-list-item-subtitle>
          </v-list-item-content>

          <v-list-item-icon>
            <v-icon>mdi-message-text</v-icon>
          </v-list-item-icon>
        </v-list-item>

        <v-divider inset></v-divider>

        <v-list-item>
          <v-list-item-icon>
            <v-icon color="indigo"> mdi-email </v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title> {{ sitter.email }} </v-list-item-title>
            <v-list-item-subtitle>Personal</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>

        <v-divider inset></v-divider>

        <v-list-item>
          <v-list-item-icon>
            <v-icon color="indigo"> mdi-information </v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title> {{ sitter.description }} </v-list-item-title>
            <v-list-item-subtitle>About</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  props: ["sitter"],
  data() {
    return {
      active: true,
    };
  },
  mounted() {
    console.log(this.sitter);
  },
  methods: {
    cancel() {
      this.$emit("close");
    },
  },
};
</script>
