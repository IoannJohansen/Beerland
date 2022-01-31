import BasePage from "./basePage";
import DatePicker from "@/DatePicker.vue";
import StatisticDrawer from "@/StatisticDrawer.vue";
import IStatistic from "../Utils/Interfaces/IStatistic";
import IDate from "../Utils/Interfaces/IDate";
import {getStatisticByDate} from "../Utils/Api/StatisticApi";

export default class StatisticPageApp extends BasePage{
    
    constructor() {
        super({
            DatePicker,
            StatisticDrawer
        });
        
        this.pageData = {
            selectedDate: this.selectedDate,
            series: this.series,
            categories: this.categories
        }
        this.pageMethods = {
            onDatePickHandler: this.onDatePickHandler
        }
    }

    selectedDate : IDate = {
        Year: new Date().getFullYear(),
        Month: new Date().getMonth()+1,
        Day: new Date().getDate(),
    }
    
    series : Array<IStatistic> = [{
        name: 'Target',
        data: []
    }, {
        name: 'Produced',
        data: []
    }]
    
    categories : Array<String> = [
        
    ]
    
    onDatePickHandler(date : IDate) {
        getStatisticByDate(date).then(data => {
            if (data.status===200) {
                this.series = [{
                    name: 'Target',
                    data: data.data.map((item)=>item.target)
                }, {
                    name: 'Produced',
                    data: data.data.map((item)=>item.produced)
                }];
                this.categories = [
                    ...data.data.map((item)=>item.beerMark)   
                ]
            } else {
                this.series = [{
                    name: 'Target',
                    data: []
                }, {
                    name: 'Produced',
                    data: []
                }];
                this.categories = []
                console.log("Error status: " + data.status)
            }
        })
    }
}

new StatisticPageApp().startVueApp()