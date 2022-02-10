﻿import axios, { AxiosResponse } from "axios";

export default class AxiosHandler {
    static axiosGet = async <I>(data : I, url : string, onSuccess : Function, onFail? : Function) => {
        const response = await axios.get<AxiosResponse>(url, {
            params:{
                ...data,
            }
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
}