<template>
    <v-app>
      <slot/>
    </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";

@Component({
  name: "App-Container"
  
})
export default class AppContainer extends Vue{

}
</script>