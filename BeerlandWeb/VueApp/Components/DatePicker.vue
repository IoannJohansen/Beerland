<template>
    <v-form class="date-input-form">
        <v-col>
            <v-select
                v-model="selectedYear"
                :items="years"
                :rules="[v => !!v || 'Item is required']"
                dense
                label="Select year"
                menu-props="auto"
                outlined
                required
                @change="changeDate(emitDatePick)"
            ></v-select>
        </v-col>
        <v-col>
            <v-select
                v-model="selectedMonth"
                :items="months"
                :rules="[v => !!v || 'Item is required']"
                dense
                label="Select month"
                menu-props="auto"
                outlined
                required
                @change="changeDate(emitDatePick)"
            ></v-select>
        </v-col>
        <v-col>
            <v-select
                v-model="selectedDay"
                :items="days"
                :rules="[v => !!v || 'Item is required']"
                dense
                label="Select day"
                menu-props="auto"
                outlined
                required
                @change="emitDatePick()"
            >
                <template v-slot:item="{ active, item, attrs, on }">
                    <v-list-item #default="{ active }" v-bind="attrs" v-on="on">
                        <v-list-item-content>
                            <v-list-item-title>
                                <v-row align="center" no-gutters>
                                    <span
                                        v-if="highlightedDays.includes(item)"
                                        class="red--text">{{
                                            item
                                        }}</span>
                                    <span v-else>{{
                                            item
                                        }}</span>
                                </v-row>
                            </v-list-item-title>
                        </v-list-item-content>
                    </v-list-item>
                </template>
            </v-select>
        </v-col>
    </v-form>

</template>

<script lang="ts">
import Component from "vue-class-component";
import Vue from "vue";
import {range, reverseRange} from "../Utils/OrderGenerators/RangeGenerator";
import {eMonthToArray, monthToNum, numToMonth} from "../Utils/Converters/MonthConverter";
import {Prop} from "vue-property-decorator";

const moment = require('moment');

@Component({
    name: "Date-Picker",
})
export default class DatePicker extends Vue {

    @Prop({type: Array, default: () => []}) highlightedDays

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