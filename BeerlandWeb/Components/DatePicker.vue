<template>
  <v-form class="date-input-form">
    <h3 align="center">Select date</h3>
    <v-col>
      <v-select
          id="year-selector"
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
          id="month-selector"
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
          id="day-selector"
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

@Component({
  name: "Date-Picker",
 
})
export default class DatePicker extends Vue {
  createRange(start, end) : Array<Number> {
    return Array.from(Array(end - start + 1).keys()).map(x => x + start)
  }
  //TODO: add n to 0 generation of year
  years = [...this.createRange(0, new Date().getFullYear())]
  months= [...this.createRange(0, 11)]
  days = [...this.createRange(0, 31)]
  selectedYear = new Date().getFullYear()
  selectedMonth = new Date().getMonth()
  selectedDay = new Date().getDate()
}
</script>

<style scoped>
.date-input-form{
  border: 1px lightgray solid;
}

</style>