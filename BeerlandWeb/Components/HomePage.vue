<template>
  <v-app>
    <h1>{{text}}</h1>
    <v-btn>
      Push me
    </v-btn>
    <a href="/statistic/index">Go there</a>
  </v-app>
</template>

<script lang="ts">
  import Vue from "vue";
  import Component from "vue-class-component";
  
  @Component({
    name: "Home-Page"
  })
  export default class HomePage extends Vue {
    text : string = "HOME PAGE!";
    homeNum : number = 1112;
  }
</script>