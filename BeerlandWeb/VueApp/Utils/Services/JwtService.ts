import jwt_decode, {JwtPayload} from "jwt-decode";

const claimTypes = require('claimtypes');

export default class JwtService {

    private static jwtTokenName = "jwt"

    public static GetJwt(): string {
        return localStorage[this.jwtTokenName];
    }

    public static SetJwt(jwtToken: string): void {
        localStorage[this.jwtTokenName] = jwtToken;
    }

    public static GetRoleFromJwt(token): string {
        const parsedToken = jwt_decode<JwtPayload>(token);
        return parsedToken[claimTypes.microsoft.role];
    }

    public static GetUserNameFromJwt(token): string {
        const parsedToken = jwt_decode<JwtPayload>(token);
        return parsedToken[claimTypes.name];
    }

    public static GetAuthenticationHeader(): object {
        return {
            "Authorization": "Bearer " + this.GetJwt()
        };
    }
}