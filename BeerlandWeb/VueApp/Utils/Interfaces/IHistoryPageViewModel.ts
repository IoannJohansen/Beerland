import IHistoryEntry from "./IHistoryEntry";

export default interface IHistoryPageViewModel {
    history: Array<IHistoryEntry>,
    actualValue: number
}