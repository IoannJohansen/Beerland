import BasePage from "./basePage";

export default class Login extends BasePage{
    constructor() {
        super({
            
        });
        this.pageData = {
            showPassword: this.showPassword,
            login: this.login,
            password: this.password,
        }
        this.pageMethods = {
            loginHandler: this.loginHandler
        }
        this.startVueApp();
    }

    private showPassword: boolean = false

    private login : String =  ''

    private password : String =  ''
    
    private loginHandler() : void {
        console.log(`Cred: ${this.login} --- ${this.password}`)
    }
}

new Login();