import BasePage from "./basePage";
import JwtService from "../Utils/Services/JwtService";


export default class home extends BasePage {

    private userRole?: string = undefined

    private userName?: string = undefined

    constructor() {
        super({});

        this.setUserInfo();

        this.pageData = {
            userRole: this.userRole,
            userName: this.userName
        }

        this.pageMethods = {
            setUserInfo: this.setUserInfo
        }

        this.startVueApp();
    }

    private setUserInfo() {
        const token = JwtService.GetJwt();
        if (token != undefined) {
            this.userName = JwtService.GetUserNameFromJwt(token);
            this.userRole = JwtService.GetRoleFromJwt(token);
        }
    }
}

new home();