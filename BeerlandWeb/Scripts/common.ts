import AppBar from "@/AppBar.vue";
import AppContainer from "@/AppContainer.vue";
import Vue from "vue";
import vuetify from "../Plugins/vuetify";

export default class BasePage {

    constructor(childPageComponents) {
        this.childPageComponents = {
            ...childPageComponents
        }
        this.startVueApp();
    }
    
    childPageComponents = {}
    
    startVueApp(){
        new Vue({
            vuetify,
            el: "#app",
            components: {
                ...this.components,
                ...this.childPageComponents
            }
        })
    }
    
    components = {
        AppBar,
        AppContainer
    }
}