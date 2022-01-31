import BasePage from "./basePage";
import DatePicker from "@/DatePicker.vue";
import StatisticDrawer from "@/StatisticDrawer.vue";

export default class StatisticPageApp extends BasePage{
    
    constructor() {
        super({
            DatePicker,
            StatisticDrawer
        },{
            selectedDate : {
                Year: new Date().getFullYear(),
                Month: new Date().getMonth()+1,
                Day: new Date().getDate(),
            }
        }
        , {
        
        });
    }
}

new StatisticPageApp()