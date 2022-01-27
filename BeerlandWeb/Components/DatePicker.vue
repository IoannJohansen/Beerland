<template>
  <v-form class="date-input-form">
    <h3 align="center">Select date</h3>
    <v-col>
      <v-select
          @change="changeDate()"
          outlined
          v-model="selectedYear"
          :items="years"
          :rules="[v => !!v || 'Item is required']"
          label="Select year"
          required
      ></v-select>
    </v-col>
    <v-col>
      <v-select
          @change="changeDate()"
          outlined
          v-model="selectedMonth"
          :items="months"
          :rules="[v => !!v || 'Item is required']"
          label="Select month"
          required
      ></v-select>
    </v-col>
    <v-col>
      <v-select
          outlined
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
import { range, reverseRange } from "../Utils/OrderGenerators/RangeGenerator";
import { eMonthToArray, monthToNum, numToMonth } from "../Utils/Converters/MonthConverter";
const moment = require('moment');
import IDate from "../Utils/Interfaces/IDate";

//TODO: ADD OUTPUT PARAMETER:   date : Idate

@Component({
  name: "Date-Picker",
  props: {
    a : Object
  }
})
export default class DatePicker extends Vue {
  
  years : Number[] = [...reverseRange(new Date().getFullYear(), new Date().getFullYear()-100)]
  
  months : String[] = [...eMonthToArray()]
  
  selectedYear : Number = new Date().getFullYear()
  
  selectedMonth : String = numToMonth(new Date().getMonth()+1)
  
  selectedDay : Number = new Date().getDate()
  
  days : Number[] = [...range(1, moment(`${this.selectedYear}-${this.addPrefixToNum(monthToNum(this.selectedMonth), 2)}`, "YYYY-MM").daysInMonth()+1)]
  
  changeDate() : void {
    this.days = [...range(1, moment(`${this.selectedYear}-${this.addPrefixToNum(monthToNum(this.selectedMonth), 2)}`, "YYYY-MM").daysInMonth()+1)]
    this.selectedDay = 1;
  }
  
  addPrefixToNum(number, requiredSize) : String {
    let s = number + "";
    while (s.length < requiredSize) s = "0" + s;
    return s;
  } 
  
}
</script>

<style scoped>
.date-input-form {
  border: 1px lightgray solid;
}

</style>