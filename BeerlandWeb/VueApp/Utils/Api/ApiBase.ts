const API_BASE = "https://localhost:7169/";
export const INDEX_PAGE = API_BASE + "home/index";

export const GET_STAT_BY_DATE = API_BASE + "statistic/getStat";

export const LOGIN = API_BASE + "auth/login";

export const GET_UNAPROVED_UNITS = API_BASE + "ProductionUnit/getUnapprovedUnits";
export const APPROVE_UNIT = API_BASE + "ProductionUnit/approveUnit";

export const GET_BEERMARKS = API_BASE + "ProductionHistory/getBeermarks";
export const GET_PROD_HISTORY = API_BASE + "ProductionHistory/getProdHistory";