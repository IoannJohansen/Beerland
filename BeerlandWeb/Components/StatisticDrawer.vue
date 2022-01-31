<template>
  <div>
    <apexcharts v-if="series[0].data.length!==0" type="bar" height="550" :options="options" :series="series" ></apexcharts>
    <h2 align="center" class="mt-14" v-else>No data found for this date</h2>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import VueApexCharts from 'vue-apexcharts';
import IStatistic from "../Utils/Interfaces/IStatistic";
import {Prop} from "vue-property-decorator";

@Component({
  name: "Statistic-Drawer",
  components: {
    apexcharts: VueApexCharts,
  }
})
export default class StatisticDrawer extends Vue {

  @Prop({
    default: [{
      name: 'Target',
      data: []
    }, {
      name: 'Produced',
      data: []
    }]
  }) readonly series! : Array<IStatistic>

  @Prop({
    default: []
  }) readonly categories! : Array<String>
  
  options = {
    xaxis: {
      categories: this.categories
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: '55%',
        endingShape: 'rounded'
      },
    },
    tooltip: {
      y: {
        formatter: function (val) {
          return `${val} Barrel`
        }
      }
    }
  }
  
}
</script>