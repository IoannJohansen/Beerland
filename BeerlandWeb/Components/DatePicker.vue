<template>
  <v-form class="date-input-form">
    <h3 align="center">Select date</h3>
    <v-col>
      <label for="year-selector">Year</label>
      <v-select
          id="year-selector"
          outlined
          v-model="select"
          :items="[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]"
          :rules="[v => !!v || 'Item is required']"
          label="Select year"
          required
      ></v-select>
    </v-col>
    <v-col>
      <label for="month-selector">Month</label>
      <v-select
          id="month-selector"
          outlined
          v-model="select"
          :items="[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]"
          :rules="[v => !!v || 'Item is required']"
          label="Select month"
          required
      ></v-select>
    </v-col>
    <v-col>
      <label for="day-selector">Day</label>
      <v-select
          id="day-selector"
          outlined
          v-model="select"
          :items="[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]"
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

}
</script>

<style scoped>
.date-input-form{
  border: 1px lightgray solid;
}

</style>