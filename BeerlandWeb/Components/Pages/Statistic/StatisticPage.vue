<template>
  <v-app>
    <h1>{{text}}</h1>
    <v-btn>
      Push me
    </v-btn>
  </v-app>
</template>

<script lang="ts">
  import Vue from "vue";
  import Component from "vue-class-component";

  @Component({
    name: "Statistic-Page"
  })
  export default class StatisticPage extends Vue {
    text : string = "STATISTIC PAGE!";
    statisticNum : number = 1222;
  }
</script>