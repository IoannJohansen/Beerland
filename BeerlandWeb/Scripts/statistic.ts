import BasePage from "./common";
import DatePicker from "@/DatePicker.vue";
import StatisticDrawer from "@/StatisticDrawer.vue";

export default class StatisticPageApp extends BasePage{
    
    constructor() {
        super({
            DatePicker,
            StatisticDrawer
        });
    }
}

new StatisticPageApp()