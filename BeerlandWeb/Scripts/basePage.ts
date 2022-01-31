import AppBar from "@/AppBar.vue";
import AppContainer from "@/AppContainer.vue";
import Vue from "vue";
import vuetify from "../Plugins/vuetify";

export default class BasePage {

    constructor(childPageComponents : Object) {
        this.childPageComponents = childPageComponents;
    }
    
    childPageComponents = {}
    
    pageData = {}
    
    pageMethods = {}

    lifeCycleHooks = {}
    
    components = {
        AppBar,
        AppContainer
    }
    
    startVueApp(){
        new Vue({
            vuetify,
            el: "#app",
            components: {
                ...this.components,
                ...this.childPageComponents
            },
            data: this.pageData,
            methods: this.pageMethods,
            ...this.lifeCycleHooks
        })
    }
}