import axios, { AxiosResponse } from "axios";
axios.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';

//TODO: add passing of headers into query
export default class AxiosHandler {
    static axiosGet = async <I>(data : I, url : string, onSuccess : Function, onFail? : Function) => {
        const response = await axios.get<AxiosResponse>(url, {
            params:{
                ...data,
            },
            validateStatus : status => true
        });
        if (response.status === 200){
            onSuccess(response.data);
        }else{
            console.log(`Error: ${response.status}`);
            if (onFail) {
                onFail(response);
            }
        }
    }

    static axiosPost = async <I>(data : I, url : string, onSuccess : Function, onFail? : Function) => {
        const response = await axios.post<AxiosResponse>(url, {
            ...data,
        }, {
                validateStatus : status => true,
            }
        );
        if (response.status === 200){
            onSuccess(response.data);
        }else{
            console.log(`Error: ${response.status}`);
            if (onFail) {
                onFail(response);
            }
        }
    }
}