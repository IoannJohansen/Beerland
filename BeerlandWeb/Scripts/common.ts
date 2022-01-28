import AppBar from "@/AppBar.vue";
import AppContainer from "@/AppContainer.vue";
import Vue from "vue";
import vuetify from "../Plugins/vuetify";

export default class BasePage {

    constructor(childPageComponents : Object, pageData : Object, pageMethods : Object) {
        this.childPageComponents = childPageComponents;
        this.pageData = pageData;
        this.pageMethods = pageMethods;
        this.startVueApp();
    }
    
    childPageComponents = {}
    
    pageData = {}
    
    pageMethods = {}
    
    startVueApp(){
        new Vue({
            vuetify,
            el: "#app",
            components: {
                ...this.components,
                ...this.childPageComponents
            },
            data: {
                ...this.pageData
            },
            methods: {
                ...this.pageMethods
            }
        })
    }
    
    components = {
        AppBar,
        AppContainer
    }
}