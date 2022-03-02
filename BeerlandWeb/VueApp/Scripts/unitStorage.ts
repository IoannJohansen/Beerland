import BasePage from "./basePage";
import IHistoryEntry from "../Utils/Interfaces/IHistoryEntry";
import IBeerMark from "../Utils/Interfaces/IBeerMark";
import AxiosHandler from "../Utils/Api/AxiosHandler";
import {GET_BEERMARKS, GET_PROD_HISTORY} from "../Utils/Api/ApiBase";
import moment from "moment";
import IHistoryPageViewModel from "../Utils/Interfaces/IHistoryPageViewModel";
import JwtService from "../Utils/Services/JwtService";

class UnitStorageApp extends BasePage {

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
    private actualVolume: number = 0
    private fetching: boolean = false;

    constructor() {
        super({});
        this.pageData = {
            beermarks: this.beermarks,
            selected: this.selected,
            headers: this.headers,
            history: this.history,
            fetching: this.fetching,
            actualVolume: this.actualVolume
        }
        this.lifeCycleHooks = {
            mounted: this.mounted,
            updated: this.updated
        }
        this.startVueApp()
    }

    private mounted() {
        AxiosHandler.axiosGet({}, GET_BEERMARKS, (data: Array<IBeerMark>) => {
            this.beermarks = data;
        }, {});
    }

    private updated() {
        if (this.selected != undefined && !this.fetching) {
            this.fetching = true;
            AxiosHandler.axiosGet({
                beerMarkId: this.beermarks[this.selected].id
            }, GET_PROD_HISTORY, (data: IHistoryPageViewModel) => {
                data.history.map(t => t.date = moment(t.date).format("YYYY.MM.DD HH:MM:SS"))
                this.history = data.history;
                this.actualVolume = data.actualValue
            }, {
                ...JwtService.GetAuthenticationHeader()
            }).then(() => {
                this.fetching = false;
            })
        } else if (this.history.length != 0 && !this.fetching) {
            this.history = []
        }
    }
}

new UnitStorageApp();