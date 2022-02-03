import {AxiosResponse} from "axios";

export const axiosResponseHandler = <T extends AxiosResponse>(data : T, onSuccess : Function, onFail : Function) => {
    data.status === 200 ? onSuccess(data) : onFail(data);
}