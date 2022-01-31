import BasePage from "./basePage";
import {Prop} from "vue-property-decorator";

class HomePageApp extends BasePage{

    constructor() {
        super({
            
        },{
            homeGreetings : String
        }, {
            
        });
        
    }
}

new HomePageApp()