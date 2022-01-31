<template>
  <div>
    <div id="chart"></div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import ApexCharts from 'apexcharts';

//TODO: add props with input data

@Component({
  name: "Statistic-Drawer",
})
export default class StatisticDrawer extends Vue {
  options = {
    chart: {
      type: 'bar',
      height: "550px",
    },
    series: [{
      name: 'Target',
      data: [44, 55, 57, 56, 61, 58, 63, 60, 66, 11, 12]
    }, {
      name: 'Produced',
      data: [76, 85, 101, 98, 87, 105, 91, 114, 94, 11, 12]
    }],
    xaxis: {
      categories: ["Beer 1", "Beer 2", "Beer 3", "Beer 4", "Beer 5", "Beer 6", "Beer 7", "Beer 8", "Beer 9", , "Beer 10", "Beer 11"]
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

  mounted() {
    let chart = new ApexCharts(document.querySelector("#chart"), this.options);
    chart.render();
  }
}
</script>