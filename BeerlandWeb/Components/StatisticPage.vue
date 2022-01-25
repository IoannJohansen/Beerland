<template>
  <div class="d-flex flex-row">
    <v-container class="col-3">
      <slot name="date-selector"></slot>
    </v-container>
    <div class="wrap-statistic">
      <slot name="statistic-drawer"></slot>
    </div>
  </div>
</template>
<script lang="ts">
  import Vue from "vue";
  import Component from "vue-class-component";

  @Component({
    name: "Statistic-Page",
  })
  export default class StatisticPage extends Vue {
    
  }
</script>

<style scoped>

.wrap-statistic{
  margin: 12px;
}

</style>