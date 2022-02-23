<template>
    <v-form class="date-input-form">
        <v-col>
            <v-select
                @change="changeDate(emitDatePick)"
                outlined
                dense
                menu-props="auto"
                v-model="selectedYear"
                :items="years"
                :rules="[v => !!v || 'Item is required']"
                label="Select year"
                required
            ></v-select>
        </v-col>
        <v-col>
            <v-select
                @change="changeDate(emitDatePick)"
                outlined
                dense
                menu-props="auto"
                v-model="selectedMonth"
                :items="months"
                :rules="[v => !!v || 'Item is required']"
                label="Select month"
                required
            ></v-select>
        </v-col>
        <v-col>
            <v-select
                @change="emitDatePick()"
                outlined
                dense
                menu-props="auto"
                v-model="selectedDay"
                :items="days"
                :rules="[v => !!v || 'Item is required']"
                label="Select day"
                required
            ></v-select>
        </v-col>
    </v-form>

</template>

<script lang="ts">
import Component from "vue-class-component";
import Vue from "vue";
import {range, reverseRange} from "../Utils/OrderGenerators/RangeGenerator";
import {eMonthToArray, monthToNum, numToMonth} from "../Utils/Converters/MonthConverter";

const moment = require('moment');

@Component({
    name: "Date-Picker",
})
export default class DatePicker extends Vue {

    private years: Number[] = [...reverseRange(new Date().getFullYear(), new Date().getFullYear() - 100)]

    private months: String[] = [...eMonthToArray()]

    private selectedYear: Number = new Date().getFullYear()

    private selectedMonth: String = numToMonth(new Date().getMonth() + 1)

    private selectedDay: Number = new Date().getDate()

    private days: Number[] = [...range(1, moment(`${this.selectedYear}-${this.addPrefixToNum(monthToNum(this.selectedMonth), 2)}`, "YYYY-MM").daysInMonth() + 1)]

    private changeDate(assignToOutputDate: Function): void {
        this.days = [...range(1, moment(`${this.selectedYear}-${this.addPrefixToNum(monthToNum(this.selectedMonth), 2)}`, "YYYY-MM").daysInMonth() + 1)]
        this.selectedDay = 1;
        assignToOutputDate();
    }

    private addPrefixToNum(number, requiredSize): String {
        let s = number + "";
        while (s.length < requiredSize) s = "0" + s;
        return s;
    }

    private emitDatePick() {
        this.$emit('pick', {
            Year: this.selectedYear,
            Month: monthToNum(this.selectedMonth),
            Day: this.selectedDay
        })
    }

}
</script>

<style scoped>

.date-input-form {
    border: 1px lightgray solid;
}

</style>