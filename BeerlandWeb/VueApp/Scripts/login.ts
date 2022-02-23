import BasePage from "./basePage";
import AxiosHandler from "../Utils/Api/AxiosHandler";
import {INDEX_PAGE, LOGIN} from "../Utils/Api/ApiBase";
import IAuthResponse from "../Utils/Interfaces/IAuthResponse";
import IAuthRequest from "../Utils/Interfaces/IAuthRequest";
import IError from "../Utils/Interfaces/IError";
import {AxiosResponse} from "axios";

export default class Login extends BasePage {
    constructor() {
        super({});
        this.pageData = {
            showPassword: this.showPassword,
            login: this.login,
            password: this.password,
            showError: this.showError,
            errorMessage: this.errorMessage,
            errorId: this.errorId
        }
        this.pageMethods = {
            loginHandler: this.loginHandler
        }
        this.startVueApp();
    }

    private showPassword: boolean = false

    private showError: boolean = false

    private login: string = ''

    private password: string = ''

    private errorMessage: string = ''

    private errorId: string = ''

    private loginHandler(): void {
        AxiosHandler.axiosPost<IAuthRequest>({
                login: this.login,
                password: this.password
            }, LOGIN, (data: IAuthResponse) => {
                localStorage.setItem("jwt", data.access_token);
                window.location.href = INDEX_PAGE;
            }, {},
            (err: AxiosResponse<IError>) => {
                this.showError = true;
                this.errorMessage = err.data.ErrorMessage;
                this.errorId = err.data.ErrorId;
            });
    }
}

new Login();