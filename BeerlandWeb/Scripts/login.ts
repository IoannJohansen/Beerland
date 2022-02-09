import BasePage from "./basePage";
import AxiosHandler from "../Utils/Api/AxiosHandler";
import {INDEX_PAGE, LOGIN} from "../Utils/Api/ApiBase";
import IAuthResponse from "../Utils/Interfaces/IAuthResponse";
import IAuthRequest from "../Utils/Interfaces/IAuthRequest";

export default class Login extends BasePage {
    constructor() {
        super({
            
        });
        this.pageData = {
            showPassword: this.showPassword,
            login: this.login,
            password: this.password,
            showAuthError: this.showAuthError,
        }
        this.pageMethods = {
            loginHandler: this.loginHandler
        }
        this.startVueApp();
    }

    private showPassword: boolean = false

    private showAuthError : boolean = false
    
    private login : string =  ''

    private password : string =  ''
    
    private loginHandler() : void {
        AxiosHandler.axiosPost<IAuthRequest>({
            login: this.login,
            password: this.password
        }, LOGIN, (data : IAuthResponse) => {
            if (data.success){
                localStorage.setItem("jwt", data.access_token);
                window.location.href = INDEX_PAGE;
            }else{
                this.showAuthError = true;
            }
        });
    }
    
    
}

new Login();