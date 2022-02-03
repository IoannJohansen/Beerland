import BasePage from "./basePage";
import DatePicker from "@/DatePicker.vue";
import StatisticDrawer from "@/StatisticDrawer.vue";
import ISeriesEntry from "../Utils/Interfaces/ISeriesEntry";
import IDate from "../Utils/Interfaces/IDate";
import { getStatisticByDate } from "../Utils/Api/StatisticApi";
import IStatisticViewModel from "../Utils/Interfaces/IStatisticViewModel";

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
        
        this.lifeCycleHooks = {
            mounted: this.mounted
        }
        this.startVueApp();
    }

    private selectedDate : IDate = {
        Year: new Date().getFullYear(),
        Month: new Date().getMonth()+1,
        Day: new Date().getDate(),
    }

    private series : Array<ISeriesEntry> = [{
        name: 'Target',
        data: []
    }, {
        name: 'Produced',
        data: []
    }]
    
    private categories : Array<String> = []
    
    private onDatePickHandler(date : IDate) {
        getStatisticByDate<Array<IStatisticViewModel>>(date, (data)=>{
                this.series = [{
                    name: 'Target',
                    data: data.data.map((item)=>item.target)
                }, {
                    name: 'Produced',
                    data: data.data.map((item)=>item.produced)
                }];
                this.categories = data.data.map((item)=>item.beerMark)
            },
            (data) => {
                this.series = [{
                    name: 'Target',
                    data: []
                }, {
                    name: 'Produced',
                    data: []
                }];
                this.categories = []
                console.log("Error status: " + data.status)
            });
    }
    
    private mounted(){
        this.onDatePickHandler(this.selectedDate);
    }
}

new StatisticPageApp()