import Vue from "vue";
import VueRouter from "vue-router";
import LoginRegisterView from "../views/LoginRegisterView.vue";
import HomeView from "@/views/HomeView.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "login",
    component: LoginRegisterView,
  },
  {
    path: "/home",
    name: "home",
    component: HomeView,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
