import BasePage from "./basePage";
import IDate from "../Utils/Interfaces/IDate";
import DatePicker from "../Components/DatePicker.vue";
import AxiosHandler from "../Utils/Api/AxiosHandler";
import IProductionUnit from "../Utils/Interfaces/IProductionUnit";
import {APPROVE_UNIT, GET_UNAPPROVED_DAYS, GET_UNAPROVED_UNITS} from "../Utils/Api/ApiBase";
import moment from "moment";
import JwtService from "../Utils/Services/JwtService";

export default class UnitApprovementApp extends BasePage {

    private headers = [
        {text: 'Date', value: 'date', align: "center", sortable: false},
        {text: 'BeerMark', value: 'beerMark', align: "center"},
        {text: 'Produced', value: 'produced', align: "center"},
        {text: 'Approve', value: 'approve', align: "center", sortable: false},
    ]

    private items: Array<IProductionUnit> = []

    private selectedDate: IDate = {
        Year: new Date().getFullYear(),
        Month: new Date().getMonth() + 1,
        Day: new Date().getDate(),
    }

    private showSuccess: boolean = false

    private showError: boolean = false

    private highlightedDays: Array<number> = []

    constructor() {
        super({
            DatePicker,
        });
        this.pageData = {
            selectedDate: this.selectedDate,
            items: this.items,
            headers: this.headers,
            showSuccess: this.showSuccess,
            highlightedDays: this.highlightedDays,
            showError: this.showError
        };
        this.pageMethods = {
            onDatePickHandler: this.onDatePickHandler,
            onApproveBtnClick: this.onApproveBtnClick,
            fetchUnapprovedUnits: this.fetchUnapprovedUnits,
            fetchUnapprovedDays: this.fetchUnapprovedDays,
            dateToString: this.dateToString
        };
        this.lifeCycleHooks = {
            mounted: this.mounted
        };
        this.startVueApp();
    }

    private onApproveBtnClick(data: IProductionUnit) {
        AxiosHandler.axiosGet<Object>({
            unitId: data.id
        }, APPROVE_UNIT, (data: IProductionUnit) => {
            this.items = this.items.filter(t => t.id != data.id);
            this.showSuccess = true;
            setTimeout(() => {
                this.showSuccess = false;
            }, 4000);
        }, {
            ...JwtService.GetAuthenticationHeader(),
        }, (res) => {
            this.showError = true;
            setTimeout(() => {
                this.showError = false;
            }, 4000);
        });
    }

    private onDatePickHandler(date: IDate) {
        this.selectedDate = date;
        this.fetchUnapprovedDays();
        this.fetchUnapprovedUnits(date);
    }

    private fetchUnapprovedUnits(date) {
        const requestParam = {
            date: `${date.Year}.${date.Month}.${date.Day}`
        }
        AxiosHandler.axiosGet<Object>(requestParam, GET_UNAPROVED_UNITS, (data: Array<IProductionUnit>) => {
            data.map(t => t.date = moment(t.date).format("YYYY.MM.DD HH:MM:SS"));
            this.items = data;
        }, {
            ...JwtService.GetAuthenticationHeader(),
        }, () => {
            this.items = []
        })
    }

    private mounted() {
        this.fetchUnapprovedUnits(this.selectedDate);
        this.fetchUnapprovedDays();
    }

    private fetchUnapprovedDays() {
        AxiosHandler.axiosGet<object>({
            date: this.dateToString(this.selectedDate)
        }, GET_UNAPPROVED_DAYS, (data: Array<number>) => {
            this.highlightedDays = data;
        }, {
            ...JwtService.GetAuthenticationHeader()
        })
    }

    private dateToString(date: IDate): string {
        return `${date.Year}.${date.Month}.${date.Day}`
    }
}

new UnitApprovementApp();