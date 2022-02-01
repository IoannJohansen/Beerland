<template>
  <div>
    <apexcharts type="bar" height="550" :series="series" :options="options" ></apexcharts>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import VueApexCharts from 'vue-apexcharts';
import ISeriesEntry from "../Utils/Interfaces/ISeriesEntry";
import { Prop } from "vue-property-decorator";
Vue.use(VueApexCharts);

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
  }) series! : Array<ISeriesEntry>

  @Prop({
    default: []
  }) categories! : Array<String>
  
  options = {
    xaxis: {  
      type: "category",
      categories: this.categories
    },
    chart: {
      id: "chart",
      type: 'bar',
      height: "500px",
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
    },
    noData: {
      text: "Select another date...",
      style: {
        fontSize: '20px',
      }
    }
  }
  
  updated(){
    ApexCharts.exec("chart", "updateOptions", {
      xaxis: {
        categories: this.categories
      }
    })
  }
  
}
</script>