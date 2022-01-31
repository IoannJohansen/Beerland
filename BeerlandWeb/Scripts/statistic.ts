import BasePage from "./basePage";
import DatePicker from "@/DatePicker.vue";
import StatisticDrawer from "@/StatisticDrawer.vue";

export default class StatisticPageApp extends BasePage{
    
    constructor() {
        super({
            DatePicker,
            StatisticDrawer
        },{
                selectedDate: {
                    Year: new Date().getFullYear(),
                    Month: new Date().getMonth()+1,
                    Day: new Date().getDate(),
                },
                series: [{
                    name: 'Target',
                    data: [1,2,3,4,5,6]
                }, {
                    name: 'Produced',
                    data: [6,5,4,3,0,0]
                }],
                categories: [
                    "Corona extra 1",
                    "Corona extra 2",
                    "Corona extra 3",
                    "Corona extra 4",
                    "Corona extra 5",
                    "Corona extra 6"
                ]
        }
        , {
            
        });
    }
}

new StatisticPageApp()