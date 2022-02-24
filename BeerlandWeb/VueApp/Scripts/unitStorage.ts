import BasePage from "./basePage";
import IHistoryEntry from "../Utils/Interfaces/IHistoryEntry";
import IBeerMark from "../Utils/Interfaces/IBeerMark";
import AxiosHandler from "../Utils/Api/AxiosHandler";
import {GET_BEERMARKS, GET_PROD_HISTORY} from "../Utils/Api/ApiBase";
import moment from "moment";

class UnitStorageApp extends BasePage {

    constructor() {
        super({});
        this.pageData = {
            beermarks: this.beermarks,
            selected: this.selected,
            headers: this.headers,
            history: this.history,
            fetching: this.fetching
        }
        this.lifeCycleHooks = {
            mounted: this.mounted,
            updated: this.updated
        }
        this.startVueApp()
    }

    private selected?: number = undefined

    private headers = [
        {
            text: 'Date',
            align: 'start',
            value: 'date',
            sortable: false
        },
        {text: 'Volume', align: 'start', value: 'actualVolume'},
    ]

    private beermarks: Array<IBeerMark> = []

    private history: Array<IHistoryEntry> = []

    private fetching: boolean = false;

    private mounted() {
        AxiosHandler.axiosGet({}, GET_BEERMARKS, (data: Array<IBeerMark>) => {
            this.beermarks = data;
        }, {});
    }

    private updated() {
        if (this.selected != undefined && !this.fetching) {
            this.fetching = true;
            console.log("Fetch");
            AxiosHandler.axiosGet({
                beerMarkId: this.beermarks[this.selected].id
            }, GET_PROD_HISTORY, (data: Array<IHistoryEntry>) => {
                data.map(t => t.date = moment(t.date).format("YYYY.MM.DD HH:MM:SS"))
                this.history = data;
            }, {}).then(() => {
                this.fetching = false;
            })
        } else if (this.history.length != 0 && !this.fetching) {
            console.log("Clear");
            this.history = []
        }
    }
}

new UnitStorageApp();