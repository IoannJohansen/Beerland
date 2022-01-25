import Vue from "vue";
import HomePage from "./HomePage.vue"
import StatisticPage from "./StatisticPage.vue"
import vuetify from "../plugins/vuetify.js";
import AppBar from "./AppBar.vue";
import AppContainer from "./AppContainer.vue";

new Vue({
    vuetify,
    el: "#app",
    components: {
        HomePage,
        StatisticPage,
        AppBar,
        AppContainer
    }
})