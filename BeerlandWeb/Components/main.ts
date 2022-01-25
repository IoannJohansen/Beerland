import Vue from "vue";
import HomePage from "@/HomePage.vue"
import StatisticPage from "@/StatisticPage.vue"
import vuetify from "../plugins/vuetify.js";

new Vue({
    vuetify,
    el: "#app",
    components: {
        HomePage,
        StatisticPage
    }
})