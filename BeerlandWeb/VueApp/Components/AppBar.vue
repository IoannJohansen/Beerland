﻿<template>
  <div>
    <v-app-bar class="d-flex justify-center" dark density="compact" elevation="2">
      <a href="/home/index">
        <v-btn text>Home</v-btn>
      </a>
      <v-divider inset vertical></v-divider>
      <a href="/ProductionUnit/UnitApprovement">
        <v-btn text>Unit approve</v-btn>
      </a>
      <v-divider inset vertical></v-divider>
      <a href="/ProductionUnit/UnitStorage">
        <v-btn text>Storage</v-btn>
      </a>
      <v-divider inset vertical></v-divider>
      <a href="/Statistic/index">
        <v-btn text>Statistic</v-btn>
      </a>
      <v-divider inset vertical></v-divider>
      <a v-if="!loggedIn" href="/Auth/index">
        <v-btn text>Login</v-btn>
      </a>
      <a v-else>
        <v-btn class="red--text" text @click="logout">Logout</v-btn>
      </a>
    </v-app-bar>
    <v-main>
      <slot/>
    </v-main>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import {INDEX_PAGE} from "../Utils/Api/ApiBase";

@Component({
  name: "App-Bar"

})
export default class AppBar extends Vue {

  private loggedIn: boolean = localStorage["jwt"] !== undefined;

  private logout() {
    localStorage.removeItem("jwt");
    window.location.href = INDEX_PAGE;
  }
}
</script>

<style scoped>
a {
  text-decoration: none;
}
</style>