import Vue from "vue";
import HomePage from "@/Pages/Home/HomePage.vue"
import StatisticPage from "@/Pages/Statistic/StatisticPage.vue"
import vuetify from "../plugins/vuetify.js";

new Vue({
    vuetify,
    el: "#app",
    components: {
        HomePage,
        StatisticPage
    }
})