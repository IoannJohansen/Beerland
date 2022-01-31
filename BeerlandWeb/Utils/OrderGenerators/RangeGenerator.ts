export const reverseRange = (start: number, end: number): number[] => {
    start = Math.floor(start);
    end = Math.floor(end);
    const diff = end - start;
    if (diff === 0) {
        return [start];
    }
    const keys = Array(Math.abs(diff) + 1).keys();
    return Array.from(keys).map(x => {
        const increment = end > start ? x : -x;
        return start + increment;
    });
}

export const range = (start, stop, step = 1) : number[] => {
    return [...Array(stop - start).keys()]
        .filter(i => !(i % Math.round(step)))
        .map(v => start + v)
}