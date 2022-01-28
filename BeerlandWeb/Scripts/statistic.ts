import BasePage from "./common";
import DatePicker from "@/DatePicker.vue";
import StatisticDrawer from "@/StatisticDrawer.vue";
import IDate from "../Utils/Interfaces/IDate";

export default class StatisticPageApp extends BasePage{
    
    constructor() {
        super({
            DatePicker,
            StatisticDrawer
        },{
            selectedDate : {
                Year: 0,
                Month: 0,
                Day: 0,
            }
            }
        , {

        });
    }
}

new StatisticPageApp()