<template>
  <div>
    <v-app-bar dark elevation="2" density="compact" class="d-flex justify-center">
      <a href="/Home/index"><v-btn text>Home</v-btn></a>
      <v-divider inset vertical></v-divider>
      <a href="/Statistic/index"><v-btn text>Statistic</v-btn></a>
    </v-app-bar>  
    <v-main>
      <slot/>
    </v-main>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";

@Component({
  name: "App-Bar"
  
})
export default class AppBar extends Vue{
  
}
</script>