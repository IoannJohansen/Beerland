import BasePage from "./basePage";
import IDate from "../Utils/Interfaces/IDate";
import DatePicker from "../Components/DatePicker.vue";
import AxiosHandler from "../Utils/Api/AxiosHandler";
import IProductionUnit from "../Utils/Interfaces/IProductionUnit";
import {APPROVE_UNIT, GET_UNAPROVED_UNITS} from "../Utils/Api/ApiBase";
import moment from "moment";

export default class UnitApprovementApp extends BasePage {
    constructor() {
        super({
            DatePicker,
        });
        this.pageData = {
            selectedDate: this.selectedDate,
            items: this.items,
            headers: this.headers,
            showAlert: this.showAlert
        };
        this.pageMethods = {
            onDatePickHandler: this.onDatePickHandler,
            onApproveBtnClick: this.onApproveBtnClick,
            fetchUnapprovedUnits: this.fetchUnapprovedUnits
        };
        this.lifeCycleHooks = {
            mounted: this.mounted
        };
        this.startVueApp();
    }

    private headers = [
        {text: 'Date', value: 'date', align: "center", sortable: false},
        {text: 'BeerMark', value: 'beerMark', align: "center"},
        {text: 'Produced', value: 'produced', align: "center"},
        {text: 'Approve', value: 'approve', align: "center", sortable: false},
    ]

    private onApproveBtnClick(data: IProductionUnit) {
        AxiosHandler.axiosGet<Object>({
            id: data.id
        }, APPROVE_UNIT, (data: IProductionUnit) => {
            this.items = this.items.filter(t => t.id != data.id);
            this.showAlert = true;
            setTimeout(() => {
                this.showAlert = false;
            }, 4000);
        }, {});
    }

    private items: Array<IProductionUnit> = []

    private selectedDate: IDate = {
        Year: new Date().getFullYear(),
        Month: new Date().getMonth() + 1,
        Day: new Date().getDate(),
    }

    private showAlert: boolean = false

    private onDatePickHandler(date: IDate) {
        this.fetchUnapprovedUnits(date);
    }

    private fetchUnapprovedUnits(date) {
        const requestParam = {
            date: `${date.Year}.${date.Month}.${date.Day}`
        }
        AxiosHandler.axiosGet<Object>(requestParam, GET_UNAPROVED_UNITS, (data: Array<IProductionUnit>) => {
            data.map(t => t.date = moment(t.date).format("YYYY.MM.DD HH.MM.SS"));
            this.items = data;
        }, {}, () => {
            this.items = []
        })
    }

    private mounted() {
        this.fetchUnapprovedUnits(this.selectedDate);
    }
}

new UnitApprovementApp();