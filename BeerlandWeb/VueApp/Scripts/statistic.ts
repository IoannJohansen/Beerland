import BasePage from "./basePage";
import DatePicker from "@/DatePicker.vue";
import StatisticDrawer from "@/StatisticDrawer.vue";
import ISeriesEntry from "../Utils/Interfaces/ISeriesEntry";
import IDate from "../Utils/Interfaces/IDate";
import IStatisticViewModel from "../Utils/Interfaces/IStatisticViewModel";
import AxiosHandler from "../Utils/Api/AxiosHandler";
import {GET_STAT_BY_DATE} from "../Utils/Api/ApiBase";

export default class StatisticPageApp extends BasePage {

    private selectedDate: IDate = {
        Year: new Date().getFullYear(),
        Month: new Date().getMonth() + 1,
        Day: new Date().getDate(),
    }
    private series: Array<ISeriesEntry> = [{
        name: 'Target',
        data: []
    }, {
        name: 'Produced',
        data: []
    }]
    private categories: Array<String> = []

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

    private onDatePickHandler(date: IDate) {
        const requestParam = {
            date: `${date.Year}.${date.Month}.${date.Day}`
        }
        AxiosHandler.axiosGet<Object>(requestParam, GET_STAT_BY_DATE, (data: Array<IStatisticViewModel>) => {
            this.series = [{
                name: 'Target',
                data: data.map((item) => item.target)
            }, {
                name: 'Produced',
                data: data.map((item) => item.produced)
            }];
            this.categories = data.map((item) => item.beerMark)
        }, {}, (req) => {
            this.series = [{
                name: 'Target',
                data: []
            }, {
                name: 'Produced',
                data: []
            }];
            this.categories = []
        })
    }

    private mounted() {
        this.onDatePickHandler(this.selectedDate);
    }
}

new StatisticPageApp()